using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Api.ViewModels
{
    public class CustomerBasketViewModel
    {
        [Required]
        public string Id { get; set; }

        public List<BasketItemViewModel> Items { get; set; }
    }
}