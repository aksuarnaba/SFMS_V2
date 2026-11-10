using Microsoft.AspNetCore.Identity;
using SFMS.Application.Common.Interfaces.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure.Security
{
    public sealed class PasswordHasher : IPasswordHasher
    {
        private readonly PasswordHasher<object> _passwordHasher = new();
        public string HashPassword(string password)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(password);

            return _passwordHasher.HashPassword(
                new object(),
                password);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
           if(string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(passwordHash))
            {
                return false;
            }

            var result = _passwordHasher.VerifyHashedPassword(new object(), passwordHash, password);

            return result == PasswordVerificationResult.Success ||
                result == PasswordVerificationResult.SuccessRehashNeeded;
        }
    }
}
