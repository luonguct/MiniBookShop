using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minishop.Infrastructure.Data;
using MiniShop.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly MiniShopDbContext _context;

        public AuthorController(MiniShopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAuthors()
        {
            var authors = await _context.Authors.ToListAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == id);
            return Ok(author);
        }
    }
}