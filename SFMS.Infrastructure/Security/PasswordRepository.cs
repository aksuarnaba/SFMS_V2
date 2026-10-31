using Microsoft.AspNetCore.Identity;
using SFMS.Application.Common.Interfaces;
using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure.Security
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly PasswordHasher<UserEntities> _hasher;

        public PasswordRepository()
        {
            _hasher = new PasswordHasher<UserEntities>();
        }

        public string HashPassword(UserEntities employee, string password)
        {
            return _hasher.HashPassword(employee, password);
        }

        public bool VerifyPassword(UserEntities employee, string hashedPassword, string password)
        {
            var result = _hasher.VerifyHashedPassword(employee, hashedPassword, password);

            return result == PasswordVerificationResult.Success
                || result == PasswordVerificationResult.SuccessRehashNeeded;
        }
    }
}
