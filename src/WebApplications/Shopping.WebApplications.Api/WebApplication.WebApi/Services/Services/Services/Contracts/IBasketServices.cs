using Shopping.WebApi.Entities;

namespace Shopping.WebApi.Services.Services.Services.Contracts;

public interface IBasketServices
{
    Task<BasketModel> GetBasket(string userName);
    Task<bool> UpdateBasket(BasketModel model);
}