using Microsoft.AspNetCore.Mvc;
using MiniShop.Core.Entities;
using MiniShop.Core.Interfaces;
using MiniShop.Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IGenericRepository<Book> _bookRepository;

        public BookController(IGenericRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var spec = new BookWithAuthorSpecification();
            var books = await _bookRepository.ListAsync(spec);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            //var book = await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);
            //return Ok(book);
            return null;
        }
    }
}