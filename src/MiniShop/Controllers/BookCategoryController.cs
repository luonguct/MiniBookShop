using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniShop.Api.Errors;
using MiniShop.Core.Entities;
using MiniShop.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniShop.Api.Controllers
{
    public class BookCategoryController : BaseApiController
    {
        private readonly IGenericRepository<BookCategory> _bookCategoryRepository;

        public BookCategoryController(IGenericRepository<BookCategory> bookCategoryRepository)
        {
            _bookCategoryRepository = bookCategoryRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Author>>> GetBookCategories()
        {
            var authors = await _bookCategoryRepository.GetAllAsync();
            return Ok(authors);
        }
    }
}