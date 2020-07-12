using MiniShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniShop.Core.Specifications
{
    public class OrdersWithItemsSpecification : BaseSpecification<Order>
    {
        public OrdersWithItemsSpecification(string email) : base(o => o.Email == email)
        {
            AddInclude(o => o.OrderItems);
            AddOrderByDescending(o => o.OrderDate);
        }

        public OrdersWithItemsSpecification(int id, string email)
            : base(o => o.OrderId == id && o.Email == email)
        {
            AddInclude(o => o.OrderItems);
        }
    }
}
