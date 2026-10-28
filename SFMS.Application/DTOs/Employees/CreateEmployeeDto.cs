using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.DTOs.Employees
{
    public sealed record CreateEmployeeDto(
        string Site,
        string EmpNum,
        string Name,
        string Dept,
        string Section,
        string Position,
        string Password
    );
}
