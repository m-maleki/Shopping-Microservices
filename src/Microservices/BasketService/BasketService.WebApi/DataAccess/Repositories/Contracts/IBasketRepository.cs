using BasketService.WebApi.Entities;

namespace BasketService.WebApi.DataAccess.Repositories.Contracts;
public interface IBasketRepository
{
    Task<ShoppingCart> GetBasket(string userName);
    Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
    Task DeleteBasket(string userName);
}