using BasketService.WebApi.Entities;

namespace BasketService.WebApi.Services.Implementations;
public interface IDiscountServices
{
    Task<Coupon> GetDiscount(string productName);
}
