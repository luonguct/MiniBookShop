using System.ComponentModel.DataAnnotations;

namespace MiniShop.Api.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public string BasketId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Province { get; set; }

        public string Zipcode { get; set; }
    }
}