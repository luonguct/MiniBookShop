using System;
using System.Collections.Generic;
using System.Text;

namespace MiniShop.SharedKernel
{
    public abstract class BaseEntity
    {
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}
