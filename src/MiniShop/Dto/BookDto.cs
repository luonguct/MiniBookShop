namespace MiniShop.Api.Dto
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Author { get; set; }
        public string BookCategory { get; set; }
    }
}