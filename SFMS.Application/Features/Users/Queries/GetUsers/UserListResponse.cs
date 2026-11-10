using SFMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Features.Users.Queries.GetUsers
{
    public sealed record UserListResponse(
            Guid Id,
            SiteEnums Site,
            string EmployeeNumber,
            string Name,
            string Department,
            string Section,
            string Position,
            UserRoleEnums Role,
            bool IsActive,
            UserAccessEnums Access,
            UserRightsEnums Rights
        );
}
