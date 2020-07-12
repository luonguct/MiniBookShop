using MiniShop.Api.Dto;
using AutoMapper;
using MiniShop.Core.Entities;
using MiniShop.Api.ViewModels;

namespace MiniShop.Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookDto>()
                .ForMember(d => d.Author, o => o.MapFrom(s => s.Author.Name))
                .ForMember(d => d.BookCategory, o => o.MapFrom(s => s.BookCategory.Name))
                .ForMember(d => d.ImageUrl, o => o.MapFrom<BookImageUrlResolver>());

            CreateMap<CustomerBasketViewModel, CustomerBasket>();
            CreateMap<BasketItemViewModel, BasketItem>();

            CreateMap<OrderDto, Order>();

            CreateMap<Order, OrderToReturnDto>();
           
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
