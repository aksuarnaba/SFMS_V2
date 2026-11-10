using SFMS.Domain.Common;
using SFMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Domain.Entities
{
    public class User : BaseEntity
    {
        public SiteEnums Site { get; set; }
        public string EmployeeNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public Guid SectionId { get; set; }
        public Section Section { get; set; } = null!;
        public Guid PositionId { get; set; }
        public Position Position { get; set; } = null!;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRoleEnums Role { get; set; } = UserRoleEnums.User;
        public bool IsActive { get; set; } = true;
        public UserAccessEnums Access { get; set; } = UserAccessEnums.Tagging;
        public UserRightsEnums Rights { get; set; } = UserRightsEnums.View;
        public string? Signature { get; set; }
    }
}
