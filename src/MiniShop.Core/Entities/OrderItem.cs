using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Core.Entities
{
    [Table("OrderItems")]
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        {
        }

        public OrderItem(int bookId, string bookTitle, string imageUrl, decimal price, int quantity)
        {
            BookId = bookId;
            BookTitle = bookTitle;
            ImageUrl = imageUrl;
            Price = price;
            Quantity = quantity;
        }

        [Key]
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}