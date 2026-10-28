using AutoMapper;
using SFMS.Application.DTOs.Employees;
using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Common.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeDto, EmployeeEntities>()
                .ForMember(
                dest => dest.Emp_num,
                opt => opt.MapFrom(src => src.EmpNum))
                .ForMember(
                dest => dest.PasswordHash,
                opt => opt.Ignore());
        }
    }
}
