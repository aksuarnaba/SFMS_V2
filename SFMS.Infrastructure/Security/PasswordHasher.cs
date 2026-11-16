using Microsoft.AspNetCore.Identity;
using SFMS.Application.Common.Interfaces.Security;
using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure.Security
{
    public sealed class PasswordHasher : IPasswordHasher
    {
        private readonly PasswordHasher<User> _passwordHasher = new();
        public string HashPassword(string password)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(password);

            return _passwordHasher.HashPassword(
                null!,
                password);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
           if(string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(passwordHash))
            {
                return false;
            }

            var result = _passwordHasher.VerifyHashedPassword(null!, passwordHash, password);

            return result is
                PasswordVerificationResult.Success or
                PasswordVerificationResult.SuccessRehashNeeded;
        }
    }
}
