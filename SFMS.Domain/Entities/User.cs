using SFMS.Domain.Common;
using SFMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Domain.Entities
{
    public class User : AuditableEntity
    {
        public SiteEnums Site { get; private set; }
        public string EmployeeNumber { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;

        public Guid DepartmentId { get; private set; }
        public Department Department { get; private set; } = null!;

        public Guid SectionId { get; private set; }
        public Section? Section { get; private set; }

        public Guid PositionId { get; private set; }
        public Position Position { get; private set; } = null!;

        public string PasswordHash { get; private set; } = string.Empty;
        public UserRoleEnums Role { get; private set; } = UserRoleEnums.User;
        public bool IsActive { get; private set; } = true;
        //public UserAccessEnums Access { get; set; } = UserAccessEnums.Tagging;
        //public UserRightsEnums Rights { get; set; } = UserRightsEnums.View;
        public string? Signature { get; private set; }

        private User()
        {

        }

        public User(
    SiteEnums site,
    string employeeNumber,
    string name,
    Guid departmentId,
    Guid sectionId,
    Guid positionId,
    string passwordHash,
    UserRoleEnums role = UserRoleEnums.User)
        {
            ValidateSite(site);
            ValidateRequiredId(departmentId, nameof(departmentId));
            ValidateRequiredId(sectionId, nameof(sectionId));
            ValidateRequiredId(positionId, nameof(positionId));

            Site = site;
            EmployeeNumber = NormalizeEmployeeNumber(employeeNumber);
            Name = NormalizeName(name);

            DepartmentId = departmentId;
            SectionId = sectionId;
            PositionId = positionId;

            SetPasswordHash(passwordHash);

            Role = role;
            IsActive = true;
        }

        public void ChangeName(string name)
        {
            Name = NormalizeName(name);
        }

        public void ChangeSite(SiteEnums site)
        {
            ValidateSite(site);
            Site = site;
        }

        public void ChangeOrganizationAssignment(
            Guid departmentId,
            Guid sectionId,
            Guid positionId)
        {
            ValidateRequiredId(departmentId, nameof(departmentId));
            ValidateRequiredId(sectionId, nameof(sectionId));
            ValidateRequiredId(positionId, nameof(positionId));

            DepartmentId = departmentId;
            SectionId = sectionId;
            PositionId = positionId;
        }

        public void ChangeRole(UserRoleEnums role)
        {
            if (!Enum.IsDefined(role))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(role),
                    role,
                    "The supplied user role is invalid.");
            }

            Role = role;
        }

        public void SetPasswordHash(string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new ArgumentException(
                    "Password hash is required.",
                    nameof(passwordHash));
            }

            PasswordHash = passwordHash;
        }

        public void SetSignature(string? signature)
        {
            Signature = string.IsNullOrWhiteSpace(signature)
                ? null
                : signature.Trim();
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        private static string NormalizeEmployeeNumber(
            string employeeNumber)
        {
            if (string.IsNullOrWhiteSpace(employeeNumber))
            {
                throw new ArgumentException(
                    "Employee number is required.",
                    nameof(employeeNumber));
            }

            return employeeNumber
                .Trim()
                .ToUpperInvariant();
        }

        private static string NormalizeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "User name is required.",
                    nameof(name));
            }

            return name.Trim();
        }

        private static void ValidateSite(SiteEnums site)
        {
            if (!Enum.IsDefined(site))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(site),
                    site,
                    "The supplied site is invalid.");
            }
        }

        private static void ValidateRequiredId(
            Guid id,
            string parameterName)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException(
                    $"{parameterName} is required.",
                    parameterName);
            }
        }
    }
}
