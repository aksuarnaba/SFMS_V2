using SFMS.Domain.Common;
using SFMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Domain.Entities
{
    public class UserEntities : BaseAuditableEntity
    {
        public string Site { get; set; } = string.Empty;
        public string Emp_num { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? Dept { get; set; }
        public string Section { get; set; } = string.Empty;
        public string? Position { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public RoleEnums Role { get; set; } = RoleEnums.User;
        public AccessEnums Access { get; set; } = AccessEnums.Tagging;
        public RightsEnums Rights { get; set; } = RightsEnums.View;
        public string Signature { get; set; } = string.Empty;
    }
}
