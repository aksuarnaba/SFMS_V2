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
        private readonly IPasswordRepository _passwordRepository;

        public CreateEmployeeHandler(IUnitOfWork unitOfWork, IPasswordRepository passwordRepository)
        {
            _unitOfWork = unitOfWork;
            _passwordRepository = passwordRepository;
        }

        public async Task<int> Handle(UserDtoRequest request)
        {
            var existing =
                await _unitOfWork.Users
                .GetByEmpNumAsync(request.Site, request.EmpNum);

            if (existing != null)
            {
                throw new Exception("Employee already exist!");
            }

            var employee = EmployeeMapper.MapToEntity(request);

            employee.PasswordHash = _passwordRepository.HashPassword(employee, request.Password);

            await _unitOfWork.Users.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            return employee.Id;
        }
    }
}
