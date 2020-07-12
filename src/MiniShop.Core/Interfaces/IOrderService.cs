using MiniShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Core.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string email, string basketId, Order shippingAddress);
        Task<List<Order>> GetOrdersForUserAsync(string buyerEmail);
        Task<Order> GetOrderByIdAsync(int id, string buyerEmail);
    }
}
