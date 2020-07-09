using System.ComponentModel.DataAnnotations;

namespace MiniShop.Api.ViewModels
{
    public class BasketItemViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public double Price { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string BookCategory { get; set; }
    }
}