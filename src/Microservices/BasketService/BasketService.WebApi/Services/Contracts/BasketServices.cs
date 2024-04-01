using Microsoft.AspNetCore.Mvc;
using BasketService.WebApi.Entities;
using BasketService.WebApi.Services.Implementations;
using BasketService.WebApi.DataAccess.Repositories.Contracts;

namespace BasketService.WebApi.Services.Contracts
{
    public class BasketServices : IBasketServices
    {
        private readonly IDiscountServices _discountServices;
        private readonly IBasketRepository _basketRepository;

        public BasketServices(IDiscountServices discountServices, IBasketRepository basketRepository)
        {
            _discountServices = discountServices;
            _basketRepository = basketRepository;
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            foreach (var item in basket.Items)
            {
                var coupon = await _discountServices.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }

            await _basketRepository.UpdateBasket(basket);

            return basket;
        }

        public async Task<ShoppingCart> GetBasket(string userName)
            => await _basketRepository.GetBasket(userName);
    }
}
