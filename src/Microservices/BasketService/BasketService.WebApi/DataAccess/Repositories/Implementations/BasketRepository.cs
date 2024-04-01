using Newtonsoft.Json;
using BasketService.WebApi.Entities;
using Microsoft.Extensions.Caching.Distributed;
using BasketService.WebApi.DataAccess.Repositories.Contracts;

namespace BasketService.WebApi.DataAccess.Repositories.Implementations;
public class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache _redisCache;

    public BasketRepository(IDistributedCache cache)
    {
        _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public async Task<ShoppingCart> GetBasket(string userName)
    {
        var basket = await _redisCache.GetStringAsync(userName);

        if (String.IsNullOrEmpty(basket))
            return null;

        return JsonConvert.DeserializeObject<ShoppingCart>(basket);
    }

    public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
    {
        await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));

        return await GetBasket(basket.UserName);
    }

    public async Task DeleteBasket(string userName)
         => await _redisCache.RemoveAsync(userName);
}