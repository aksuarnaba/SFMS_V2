using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Domain.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTimeOffset CreatedAt { get; private set; }
        public string? CreatedBy { get; private set; }

        public DateTimeOffset? LastModifiedAt { get; private set; }
        public string? LastModifiedBy { get; private set; }

        protected AuditableEntity()
        {
            CreatedAt = DateTimeOffset.UtcNow;
        }

        public void SetCreatedAudit(string? userId)
        {
            CreatedAt = DateTimeOffset.UtcNow;
            CreatedBy = userId;
        }

        public void SetModifiedAudit(string? userId)
        {
            LastModifiedAt = DateTimeOffset.UtcNow;
            LastModifiedBy = userId;
        }
    }
}
