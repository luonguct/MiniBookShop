using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShop.Api.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [MaxLength(255, ErrorMessage = @"Emails are not allowed to exceed 255 characters")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
