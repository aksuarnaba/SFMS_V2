using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Features.Users.Queries.GetUsers
{
    public sealed record GetUsersQuery(
        int PageNumber = 1,
        int PageSize = 20)
        : IRequest<GetUsersResponse>;
}
