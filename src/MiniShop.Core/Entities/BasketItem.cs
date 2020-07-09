using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Core.Entities
{
    public class BasketItem
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string BookName { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        [MaxLength(4000)]
        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        public string ImageUrl { get; set; }

        [MaxLength(255)]
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Author { get; set; }

        [MaxLength(255)]
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string BookCategory { get; set; }
    }
}