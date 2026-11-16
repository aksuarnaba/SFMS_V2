using MediatR;
using SFMS.Application.Common.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Features.Users.Queries.GetUsers
{
    public sealed class GetUsersQueryHandler(IUserRepository userRepository)
        : IRequestHandler<GetUsersQuery, GetUsersResponse>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<GetUsersResponse> Handle(
            GetUsersQuery request,
            CancellationToken cancellationToken)
        {
            if (request.PageNumber < 1)
                throw new ArgumentException("Page number must be at least 1.");

            if (request.PageSize < 1 || request.PageSize > 100)
                throw new ArgumentException("Page size must be between 1 and 100.");

            var (users, totalCount) =
                await _userRepository.GetPagedAsync(
                    request.PageNumber,
                    request.PageSize,
                    cancellationToken);

            var response = users.Select(user => new UserListResponse(
                user.Id,
                user.Site,
                user.EmployeeNumber,
                user.Name,
                user.Department?.Name ?? "N/A",
                user.Section?.Name ?? "N/A",
                user.Position?.Name ?? "N/A",
                user.Role,
                user.IsActive
            )).ToList();

            var totalPages = (int)Math.Ceiling(
                totalCount / (double)request.PageSize);

            return new GetUsersResponse(
                response,
                totalCount,
                request.PageNumber,
                request.PageSize,
                totalPages);
        }
    }
}
