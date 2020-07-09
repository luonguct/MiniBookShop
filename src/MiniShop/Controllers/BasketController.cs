using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniShop.Api.ViewModels;
using MiniShop.Core.Entities;
using MiniShop.Core.Interfaces;
using System.Threading.Tasks;

namespace MiniShop.Api.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasket>> GetBasketAsync([FromRoute] string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);

            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasketAsync(CustomerBasketViewModel basketVm)
        {
            var customerBasket = _mapper.Map<CustomerBasketViewModel, CustomerBasket>(basketVm);

            var updatedBasket = await _basketRepository.UpdateBasketAsync(customerBasket);

            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketRepository.DeleteBasketAsync(id);
        }
    }
}