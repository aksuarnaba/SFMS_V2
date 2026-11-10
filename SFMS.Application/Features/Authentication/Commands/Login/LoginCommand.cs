using MediatR;
using SFMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Features.Authentication.Commands.Login
{
    public sealed record LoginCommand(
        SiteEnums Site,
        string EmployeeNumber,
        string Password) : IRequest<LoginResponse>;
}
