using MiniShop.Core.SharedKernel;
using System.Collections.Generic;

namespace MiniShop.Core.Entities
{
    public abstract class BaseEntity
    {
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}