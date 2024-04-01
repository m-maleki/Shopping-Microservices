using Shopping.WebApi.Entities;
using Shopping.WebApi.Services.Services.AppServices.Contracts;
using Shopping.WebApi.Services.Services.Services.Contracts;

namespace Shopping.WebApi.Services.Services.AppServices.Implementations
{
    public class BasketAppServices : IBasketAppServices
    {
        private readonly IBasketServices _basketServices;
        private readonly IProductServices _productServices;

        public BasketAppServices(IBasketServices basketServices, IProductServices productServices)
        {
            _basketServices = basketServices;
            _productServices = productServices;
        }

        public async Task<BasketModel> GetBasket(string userName)
            => await _basketServices.GetBasket(userName);

        public async Task UpdateBasket(string email, int productId)
        {
            var basket = await _basketServices.GetBasket(email);
            var product = await _productServices.GetBy(productId);

            if (basket == null || product == null)
                throw new Exception("Basket or product not found");

            var existingItem = basket.Items
                .FirstOrDefault(x => x.ProductId == product.Id.ToString());

            if (existingItem != null) existingItem.Quantity++;
            else
            {
                basket.Items.Add(new BasketItemModel
                {
                    ProductName = product.Name,
                    Color = "Black",
                    Price = product.Price,
                    ProductId = product.Id.ToString(),
                    Quantity = 1
                });
            }

            await _basketServices.UpdateBasket(basket);
        }

        public async Task RemoveItemFromBasket(string email, int productId)
        {
            var basket = await _basketServices.GetBasket(email);

            var basketItem = basket.Items.First(x => x.ProductId == productId.ToString());

            basket.Items.Remove(basketItem);

            await _basketServices.UpdateBasket(basket);
        }
    }
}
