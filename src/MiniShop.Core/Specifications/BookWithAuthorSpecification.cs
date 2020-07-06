using MiniShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniShop.Core.Specifications
{
    public class BookWithAuthorSpecification : BaseSpecification<Book>
    {
        public BookWithAuthorSpecification()
        {
            AddInclude(x => x.Author);
        }

        public BookWithAuthorSpecification(int id) : base(x => x.BookId == id)
        {
            AddInclude(x => x.Author);
        }
    }
}
