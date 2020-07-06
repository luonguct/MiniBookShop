using MiniShop.Core.Entities;

namespace MiniShop.Core.Specifications
{
    public class BookWithAuthorSpecification : BaseSpecification<Book>
    {
        public BookWithAuthorSpecification(BookSpecParams bookParams)
            : base(x =>
                (string.IsNullOrEmpty(bookParams.Search) || x.Title.ToLower().Contains(bookParams.Search)) &&
                (!bookParams.AuthorId.HasValue || x.AuthorId == bookParams.AuthorId) &&
                (!bookParams.BookCategoryId.HasValue || x.BookCategoryId == bookParams.BookCategoryId)
            )
        {
            AddInclude(x => x.Author);
            AddInclude(x => x.BookCategory);
            AddOrderBy(x => x.Title);
            ApplyPaging(bookParams.PageSize * (bookParams.PageIndex - 1), bookParams.PageSize);

            if (!string.IsNullOrEmpty(bookParams.Sort))
            {
                switch (bookParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;

                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;

                    default:
                        AddOrderBy(n => n.Title);
                        break;
                }
            }
        }

        public BookWithAuthorSpecification(int id) : base(x => x.BookId == id)
        {
            AddInclude(x => x.Author);
            AddInclude(x => x.BookCategory);
        }
    }
}