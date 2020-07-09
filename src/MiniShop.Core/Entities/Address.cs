using System;
using System.Collections.Generic;
using System.Text;

namespace MiniShop.Core.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
