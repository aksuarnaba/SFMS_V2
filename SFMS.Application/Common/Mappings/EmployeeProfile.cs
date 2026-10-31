using SFMS.Application.DTOs.Employees;
using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Common.Mappings
{
    public static class EmployeeMapper
    {
        public static UserEntities MapToEntity(UserDtoRequest request)
        {
            return new UserEntities
            {
                Site = request.Site,
                Emp_num = request.EmpNum,
                Name = request.Name,
                Dept = request.Dept,
                Section = request.Section,
                Position = request.Position,
                PasswordHash = string.Empty,
                Signature = string.Empty
            };
        }
    }
}
