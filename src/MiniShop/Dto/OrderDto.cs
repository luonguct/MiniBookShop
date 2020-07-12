namespace MiniShop.Api.Dto
{
    public class OrderDto
    {
        public string BasketId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string Zipcode { get; set; }
    }
}