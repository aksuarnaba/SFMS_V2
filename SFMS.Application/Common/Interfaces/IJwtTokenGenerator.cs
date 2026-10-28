using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Common.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(EmployeeEntities employee);
    }
}
