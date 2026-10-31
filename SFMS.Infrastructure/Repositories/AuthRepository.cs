using SFMS.Application.Common.Interfaces;
using SFMS.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Infrastructure.Repositories
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordRepository _passwordRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(IUnitOfWork unitOfWork, 
            IPasswordRepository passwordRepository, 
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _passwordRepository = passwordRepository ?? throw new ArgumentNullException(nameof(passwordRepository));
            _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
        }

        public async Task<string?> LoginAsync(LoginRequest request, CancellationToken ct = default)
        {
            var employee =
                await _unitOfWork.Users
                .GetByEmpNumAsync(request.Site, request.EmpNum);

            if (employee is null) return null;

            bool isPasswordValid = _passwordRepository.VerifyPassword(employee, employee.PasswordHash, request.Password);

            if (!isPasswordValid) return null;

            return _jwtTokenGenerator.GenerateToken(employee);
        }
    }
}
