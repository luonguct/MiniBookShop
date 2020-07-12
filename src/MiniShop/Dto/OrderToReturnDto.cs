using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShop.Api.Dto
{
    public class OrderToReturnDto
    {
        public int OrderId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string Zipcode { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    
    }
}
