using AutoMapper;
using Microsoft.Extensions.Configuration;
using MiniShop.Api.Dto;
using MiniShop.Core.Entities;

namespace MiniShop.Api.Helpers
{
    public class OrderItemImageUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration _config;

        public OrderItemImageUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
            {
                return _config["ApiUrl"] + source.ImageUrl;
            }

            return null;
        }
    }
}