using SFMS.Application.Common.Interfaces;
using SFMS.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure.Service
{
    public class AuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordRepository _passwordRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public async Task<string?> LoginAsync(LoginRequest request)
        {
            var employee =
                await _unitOfWork.Employees
                .GetByEmpNumAsync(request.Site, request.EmpNum);

            if (employee is null) return null;

            bool valid = _passwordRepository.VerifyPassword(employee, employee.PasswordHash, request.Password);

            if (!valid) return null;

            return _jwtTokenGenerator.GenerateToken(employee);
        }
    }
}
