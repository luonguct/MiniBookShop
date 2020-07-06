using MiniShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniShop.Core.Specifications
{
    public class BookWithFilterForCountSpecification : BaseSpecification<Book>
    {
        public BookWithFilterForCountSpecification(BookSpecParams bookParams)
            : base(x =>
                (string.IsNullOrEmpty(bookParams.Search) || x.Title.ToLower().Contains(bookParams.Search)) &&
                (!bookParams.AuthorId.HasValue || x.AuthorId == bookParams.AuthorId) &&
                (!bookParams.BookCategoryId.HasValue || x.BookCategoryId == bookParams.BookCategoryId)
            )
        {
        }
    }
}
