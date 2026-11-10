using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset? LastModifiedAt { get; private set; }
        public string? CreatedBy { get; private set; }
        public string? ModifiedAt { get; private set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTimeOffset.UtcNow;
        }

        public void UpdateTimeStamp()
        {
            LastModifiedAt = DateTimeOffset.UtcNow;
        }
    }
}
