using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Core.Entities
{
    [Table("Orders")]
    public class Order : BaseEntity
    {
        public Order()
        {
        }

        public Order(Order order)
        {
            FirstName = order.FirstName;
            LastName = order.LastName;
            PhoneNumber = order.PhoneNumber;
            Address = order.Address;
            Province = order.Province;
            Zipcode = order.Zipcode;
        }

        public Order(List<OrderItem> orderItems, Order order)
        {
            OrderItems = orderItems;
            Email = order.Email;
            FirstName = order.FirstName;
            LastName = order.LastName;
            PhoneNumber = order.PhoneNumber;
            Address = order.Address;
            Province = order.Province;
            Zipcode = order.Zipcode;
            Total = order.Total;
        }


        [Key]
        public int OrderId { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string Zipcode { get; set; }
        public double Total { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
    }
}