using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Common.Interfaces
{
    public interface IPasswordRepository
    {
        string HashPassword(UserEntities employee, string password);
        bool VerifyPassword(UserEntities employee, string hashedPassword, string password);
    }
}
