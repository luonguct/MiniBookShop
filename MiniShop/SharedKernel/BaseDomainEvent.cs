using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniShop.SharedKernel
{
    public abstract class BaseDomainEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
