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

        public Order(string firstName, string lastName, int phoneNumber, string address, string province, string zipcode, double total, List<OrderItem> orderItems)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
            Province = province;
            Zipcode = zipcode;
            Total = total;
            OrderItems = orderItems;
        }

        [Key]
        public int OrderId { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
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