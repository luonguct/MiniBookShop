using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiniShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        [HttpGet]
        public string GetAuthors()
        {
            return "return list of authors";
        }

        [HttpGet("{id}")]
        public string GetAuthor(int id)
        {
            return $"return single author with id of {id}";
        }
    }
}