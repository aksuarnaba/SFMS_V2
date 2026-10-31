using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SFMS.Application.Common.Interfaces;
using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SFMS.Infrastructure.Security
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(UserEntities employee)
        {
            var key =
                _configuration["JwtSettings:Key"]
                ?? throw new Exception("JWT Key not configured.");

            var securityKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(key));

            var credentials =
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub,
                    employee.Id.ToString()),

                new("emp_num",
                    employee.Emp_num),

                new("site",
                    employee.Site),

                new("role",
                    employee.Role.ToString()),

                new("access",
                    employee.Access.ToString()),

                new("rights",
                    employee.Rights.ToString())
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}
