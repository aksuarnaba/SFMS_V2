using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Domain.Common
{
    public class AuditableEntity
    {
        public DateTimeOffset CreateAt { get; private set; }
        public string? CreatedBy { get; private set; }
        public DateTimeOffset? LastModifiedAt { get; private set; }
        public string? ModifiedBy { get; private set; }
    }
}
