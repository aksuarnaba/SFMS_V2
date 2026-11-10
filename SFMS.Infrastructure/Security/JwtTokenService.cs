using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SFMS.Application.Common.Interfaces.Security;
using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SFMS.Infrastructure.Security
{
    public sealed class JwtTokenService : ITokenService
    {
        private readonly JwtSettings _settings;

        public JwtTokenService(IOptions<JwtSettings> options)
        {
            _settings = options.Value;

            if (string.IsNullOrWhiteSpace(_settings.Issuer) ||
                string.IsNullOrWhiteSpace(_settings.Audience) ||
                string.IsNullOrWhiteSpace(_settings.SecretKey))
            {
                throw new InvalidOperationException(
                    "JWT configuration is incomplete.");
            }

            if (Encoding.UTF8.GetByteCount(_settings.SecretKey) < 32)
            {
                throw new InvalidOperationException(
                    "JWT secret key must contain at least 32 bytes.");
            }

            if (_settings.ExpirationMinutes <= 0)
            {
                throw new InvalidOperationException(
                    "JWT expiration must be greater than zero.");
            }
        }

        public string GenerateAccessToken(User user)
        {
            var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.EmployeeNumber),
            new(ClaimTypes.Role, user.Role.ToString()),

            new("site", user.Site.ToString()),
            new("access", user.Access.ToString()),
            new("rights", user.Rights.ToString())
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_settings.SecretKey));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(
                _settings.ExpirationMinutes);

            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
