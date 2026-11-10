using MediatR;
using SFMS.Application.Common.Interfaces.Persistence;
using SFMS.Application.Common.Interfaces.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Features.Authentication.Commands.Login
{
    public sealed record LoginCommandHandler
        : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(IUserRepository userRepository,
                                    IPasswordHasher passwordHasher,
                                    ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> Handle(
           LoginCommand request,
           CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmployeeNumberAsync(
                request.Site,
                request.EmployeeNumber,
                cancellationToken);

            if (user is null || !user.IsActive)
            {
                throw new UnauthorizedAccessException(
                    "Invalid employee number or password.");
            }

            var isPasswordValid = _passwordHasher.VerifyPassword(
                request.Password,
                user.PasswordHash);

            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException(
                    "Invalid employee number or password.");
            }

            var accessToken = _tokenService.GenerateAccessToken(user);

            return new LoginResponse(
                accessToken,
                user.EmployeeNumber,
                user.Name,
                user.Site,
                user.Role,
                user.Access,
                user.Rights);
        }
    }
}
