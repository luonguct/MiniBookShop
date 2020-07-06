using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniShop.Infrastructure.Data;
using MiniShop.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniShop.Core.Interfaces;

namespace MiniShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IGenericRepository<Author> _authorRepository;


        public AuthorController(IGenericRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAuthors()
        {
            var authors = await _authorRepository.GetAllAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            return Ok(author);
        }
    }
}