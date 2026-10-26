using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        private readonly List<BaseEvent> _domainEvents = [];

        public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(BaseEvent eventItem) => _domainEvents.Add(eventItem);
        public void RemoveDomainEvent(BaseEvent eventItem) => _domainEvents.Remove(eventItem);
        public void ClearDomainEvent(BaseEvent eventItem) => _domainEvents.Clear();
    }
}
