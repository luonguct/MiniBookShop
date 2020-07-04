using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MiniShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public string GetBooks()
        {
            return "return list of books";
        }

        [HttpGet("{id}")]
        public string GetBook(int id)
        {
            return $"return single book with id of {id}";
        }
    }
}