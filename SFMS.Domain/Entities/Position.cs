using SFMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Domain.Entities
{
    public class Position : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; } = [];
    }
}
