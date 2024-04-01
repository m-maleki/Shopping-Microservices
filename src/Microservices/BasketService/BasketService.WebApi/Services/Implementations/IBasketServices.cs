using BasketService.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BasketService.WebApi.Services.Implementations;
public interface IBasketServices
{
    Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
    Task<ShoppingCart> GetBasket(string userName);
}