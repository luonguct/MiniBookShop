using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniShop.Api.Dto;
using MiniShop.Api.Errors;
using MiniShop.Api.Helpers;
using MiniShop.Core.Entities;
using MiniShop.Core.Interfaces;
using MiniShop.Core.Specifications;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MiniShop.Api.Controllers
{
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pagination<List<BookDto>>>> GetBooks([FromQuery]BookSpecParams bookParams)
        {
            var countSpec = new BookWithFilterForCountSpecification(bookParams);
            var spec = new BookWithAuthorSpecification(bookParams);

            var totalItems = await _bookRepository.CountAsync(countSpec);
            var books = await _bookRepository.ListAsync(spec);

            var data = _mapper.Map<List<Book>, List<BookDto>>(books);

            return Ok(new Pagination<BookDto>(bookParams.PageIndex, bookParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var spec = new BookWithAuthorSpecification(id);
            var book = await _bookRepository.GetEntityWithSpec(spec);
            if (book == null) return NotFound(new ApiResponse((int)HttpStatusCode.NotFound));

            return _mapper.Map<Book, BookDto>(book);
        }
    }
}