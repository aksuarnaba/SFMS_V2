using SFMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Features.Authentication.Commands.Login
{
    public sealed record LoginResponse(
        string AccessToken,
        string EmployeeNumber,
        string Name,
        SiteEnums Site,
        UserRoleEnums Role,
        UserAccessEnums Access,
        UserRightsEnums Rights);
}
