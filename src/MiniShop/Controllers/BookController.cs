using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniShop.Api.Dto;
using MiniShop.Api.Errors;
using MiniShop.Core.Entities;
using MiniShop.Core.Interfaces;
using MiniShop.Core.Specifications;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MiniShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : BaseApiController
    {
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookController(
            IGenericRepository<Book> bookRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetBooks()
        {
            var spec = new BookWithAuthorSpecification();
            var books = await _bookRepository.ListAsync(spec);
            var data = _mapper
               .Map<List<Book>, List<BookDto>>(books);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var spec = new BookWithAuthorSpecification(id);
            var book = await _bookRepository.GetEntityWithSpec(spec);
            if (book == null) return NotFound(new ApiResponse((int)HttpStatusCode.NotFound));

            return _mapper.Map<Book, BookDto>(book);
        }
    }
}