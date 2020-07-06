using MiniShop.Api.Dto;
using AutoMapper;
using MiniShop.Core.Entities;

namespace MiniShop.Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookDto>()
                .ForMember(d => d.Author, o => o.MapFrom(s => s.Author.Name))
                .ForMember(d => d.ImageUrl, o => o.MapFrom<BookImageUrlResolver>()); ;
        }
    }
}
