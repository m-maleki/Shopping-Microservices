using Shopping.WebApi.Entities;

namespace Shopping.WebApi.Services.Services.AppServices.Contracts
{
    public interface IBasketAppServices
    {
        Task<BasketModel> GetBasket(string userName);
        Task UpdateBasket(string email, int productId);
        Task RemoveItemFromBasket(string email, int productId);
    }
}
