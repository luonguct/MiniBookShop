namespace MiniShop.Api.Dto
{
    public class OrderDto
    {
        public string BasketId { get; set; }
        public AddressDto Address { get; set; }
    }
}