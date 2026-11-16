using SFMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Domain.Entities
{
    public class Department : AuditableEntity
    {
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;

        public ICollection<User> Users { get; private set; } = [];
        public ICollection<Section> Sections { get; private set; } = [];

        private Department()
        {

        }

        public Department(string code, string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(code);
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            Code = code.Trim().ToUpperInvariant();
            Name = name.Trim().ToUpperInvariant();
        }

        public void ChangeName(string name)
        {
            Code = NormalizeName(name);
        }

        public void ChangeCode(string code)
        {
            Code = NormalizeCode(code);
        }

        private static string NormalizeCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Deparment code is required.",
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
                    "Department name is required.",
                    nameof(name));
            }

            return name
                .Trim()
                .ToUpperInvariant();
        }
    }
}
