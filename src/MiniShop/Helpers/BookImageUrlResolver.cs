using AutoMapper;
using Microsoft.Extensions.Configuration;
using MiniShop.Api.Dto;
using MiniShop.Core.Entities;

namespace MiniShop.Api.Helpers
{
    public class BookImageUrlResolver : IValueResolver<Book, BookDto, string>
    {
        private readonly IConfiguration _config;

        public BookImageUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Book source, BookDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
            {
                return _config["ApiUrl"] + source.ImageUrl;
            }

            return null;
        }
    }
}