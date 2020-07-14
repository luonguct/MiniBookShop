using System;

namespace MiniShop.Api.Dto
{
    public class UserOrderDto
    {
        public int OrderId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int Total { get; set; }
        public string Status { get; set; }
    }
}