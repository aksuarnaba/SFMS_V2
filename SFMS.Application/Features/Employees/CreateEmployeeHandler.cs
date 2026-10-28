using AutoMapper;
using SFMS.Application.Common.Interfaces;
using SFMS.Application.Common.Mappings;
using SFMS.Application.DTOs.Employees;
using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Features.Employees
{
    public class CreateEmployeeHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordRepository _passwordRepository;

        public CreateEmployeeHandler(IUnitOfWork unitOfWork, IMapper mapper, IPasswordRepository passwordRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordRepository = passwordRepository;
        }

        public async Task<int> Handle(CreateEmployeeDto request)
        {
            var existing =
                await _unitOfWork.Employees
                .GetByEmpNumAsync(request.Site, request.EmpNum);

            if (existing != null)
            {
                throw new Exception("Employee already exist!");
            }

            var employee = _mapper.Map<EmployeeEntities>(request);

            employee.PasswordHash = _passwordRepository.HashPassword(employee, request.Password);

            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            return employee.Id;
        }
    }
}
