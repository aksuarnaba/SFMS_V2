using SFMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Domain.Entities
{
    public class Section : AuditableEntity
    {
        public string Code { get; private set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public Guid DepartmentId { get; private set; }
        public Department Department { get; private set; } = null!;

        public ICollection<User> Users { get; set; } = [];

        private Section()
        {
        }

        public Section(
            string code,
            string name,
            Guid departmentId)
        {
            Code = NormalizeCode(code);
            Name = NormalizeName(name);

            SetDepartment(departmentId);
        }

        public void ChangeName(string name)
        {
            Name = NormalizeName(name);
        }

        public void ChangeCode(string code)
        {
            Code = NormalizeCode(code);
        }

        public void ChangeDepartment(Guid departmentId)
        {
            SetDepartment(departmentId);
        }

        private void SetDepartment(Guid departmentId)
        {
            if (departmentId == Guid.Empty)
            {
                throw new ArgumentException(
                    "Department is required.",
                    nameof(departmentId));
            }

            DepartmentId = departmentId;
        }

        private static string NormalizeCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException(
                    "Section code is required.",
                    nameof(code));
            }

            return code
                .Trim()
                .ToUpperInvariant();
        }

        private static string NormalizeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "Section name is required.",
                    nameof(name));
            }

            return name
                .Trim()
                .ToUpperInvariant();
        }
    }
}
