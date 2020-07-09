using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using MiniShop.Core.Entities;
using MiniShop.Core.Interfaces;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiniShop.Infrastructure.Data.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IConfiguration _configuration;

        public BasketRepository(IDistributedCache distributedCache, IConfiguration configuration)
        {
            _distributedCache = distributedCache;
            _configuration = configuration;
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            byte[] cacheData = await _distributedCache.GetAsync(basketId);
            if (cacheData != null)
            {
                return JsonSerializer.Deserialize<CustomerBasket>(Encoding.UTF8.GetString(cacheData));
            }

            return default;
        }

        public async Task DeleteBasketAsync(string basketId)
        {
            await _distributedCache.RemoveAsync(basketId);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            byte[] byteValue = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(basket));

            await _distributedCache.SetAsync(basket.Id, byteValue, new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromDays(_configuration.GetValue<int>("CacheDurationInDays"))));

            return await GetBasketAsync(basket.Id);
        }
    }
}