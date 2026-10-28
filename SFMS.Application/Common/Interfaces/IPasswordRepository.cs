using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Common.Interfaces
{
    public interface IPasswordRepository
    {
        string HashPassword(EmployeeEntities employee, string password);
        bool VerifyPassword(EmployeeEntities employee, string hashedPassword, string password);
    }
}
