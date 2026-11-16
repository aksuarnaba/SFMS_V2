using SFMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Domain.Entities
{
    public class Position : AuditableEntity
    {
        public string Code { get; private set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; } = [];

        private Position()
        {
        }

        public Position(
            string code,
            string name)
        {
            Code = NormalizeCode(code);
            Name = NormalizeName(name);
        }

        public void ChangeName(string name)
        {
            Name = NormalizeName(name);
        }

        public void ChangeCode(string code)
        {
            Code = NormalizeCode(code);
        }

        private static string NormalizeCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException(
                    "Position code is required.",
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
                    "Position name is required.",
                    nameof(name));
            }

            return name
                .Trim()
                .ToUpperInvariant();
        }
    }
}
