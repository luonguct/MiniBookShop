using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniShop.Infrastructure.Data;
using MiniShop.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniShop.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MiniShop.Api.Errors;
using System.Net;

namespace MiniShop.Api.Controllers
{
    public class AuthorController : BaseApiController
    {
        private readonly IGenericRepository<Author> _authorRepository;


        public AuthorController(IGenericRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Author>>> GetAuthors()
        {
            var authors = await _authorRepository.GetAllAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null) return NotFound(new ApiResponse((int)HttpStatusCode.NotFound));

            return Ok(author);
        }
    }
}