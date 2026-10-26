using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Domain.Common
{
    public abstract class BaseEvent
    {
        public DateTime OccuredOn { get; } = DateTime.UtcNow;
    }
}
