using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniShop.Data.DbContext;
using MiniShop.Data.Entities;

namespace MiniShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly MiniShopDbContext _context;

        public BookController(MiniShopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);
            return Ok(book);
        }
    }
}