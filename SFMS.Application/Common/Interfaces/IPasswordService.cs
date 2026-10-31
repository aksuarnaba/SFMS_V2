using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Common.Interfaces
{
    public interface IPasswordService
    {
        string HashPassword(UserEntities employee, string password);
        bool VerifyPassword(UserEntities employee, string hash, string password);
    }
}
