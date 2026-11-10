using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Features.Users.Queries.GetUsers
{
    public sealed record GetUsersResponse(
    IReadOnlyList<UserListResponse> Users,
    int TotalCount,
    int PageNumber,
    int PageSize,
    int TotalPages);
}
