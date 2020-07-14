using MiniShop.Core.Entities;
using MiniShop.Core.Interfaces;
using MiniShop.Core.Specifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShop.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IBasketRepository basketRepo, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _basketRepo = basketRepo;
        }

        public async Task<Order> CreateOrderAsync(string email, string basketId, Order order)
        {
            // get basket from the repo
            var basket = await _basketRepo.GetBasketAsync(basketId);

            // get items from the product repo
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var book = await _unitOfWork.Repository<Book>().GetByIdAsync(item.Id);
                var orderItem = new OrderItem(book.BookId, book.Title, book.ImageUrl, book.Price, item.Quantity);
                items.Add(orderItem);
            }

            // create order
            order.Total = items.Sum(item => item.Price * item.Quantity);
            order.Email = email;
            var newOrder = new Order(items, order);
            _unitOfWork.Repository<Order>().Add(newOrder);

            // save to db
            var result = await _unitOfWork.Complete();
            if (result <= 0) return null;

            // return order
            return order;
        }

        public async Task<Order> GetOrderByIdAsync(int id, string email)
        {
            var spec = new OrdersWithItemsSpecification(id, email);

            return await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
        }

        public async Task<List<Order>> GetOrdersForUserAsync(string email)
        {
            var spec = new OrdersWithItemsSpecification(email);

            return await _unitOfWork.Repository<Order>().ListAsync(spec);
        }
    }
}