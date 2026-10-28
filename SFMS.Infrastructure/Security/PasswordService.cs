using Microsoft.AspNetCore.Identity;
using SFMS.Application.Common.Interfaces;
using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure.Security
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<EmployeeEntities> _hasher;

        public PasswordService()
        {
            _hasher = new PasswordHasher<EmployeeEntities>();
        }

        public string HashPassword(EmployeeEntities employee, string password)
        {
            return _hasher.HashPassword(employee, password);
        }

        public bool VerifyPassword(EmployeeEntities employee, string hashedPassword, string password)
        {
            var result = _hasher.VerifyHashedPassword(employee, hashedPassword, password);

            return result == PasswordVerificationResult.Success
                || result == PasswordVerificationResult.SuccessRehashNeeded;
        }
    }
}
