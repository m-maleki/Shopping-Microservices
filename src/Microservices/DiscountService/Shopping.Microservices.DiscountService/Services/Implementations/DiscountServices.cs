using DiscountService.WebApi.Entities;
using DiscountService.WebApi.Repositories.Contracts;
using DiscountService.WebApi.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DiscountService.WebApi.Services.Implementations;
public class DiscountServices : IDiscountServices
{
    private readonly IDiscountRepository _discountRepository;

    public DiscountServices(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    public async Task<Coupon> GetDiscount(string productName)
        => await _discountRepository.GetDiscount(productName);

    public async Task<Coupon> CreateDiscount(Coupon coupon)
    {
        var result =  await _discountRepository.CreateDiscount(coupon);
        return await GetDiscount(coupon.ProductName);
    }
}