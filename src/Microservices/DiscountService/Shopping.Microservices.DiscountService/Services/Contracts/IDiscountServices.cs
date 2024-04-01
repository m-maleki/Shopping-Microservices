using DiscountService.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DiscountService.WebApi.Services.Contracts;
public interface IDiscountServices
{
    Task<Coupon> GetDiscount(string productName);
    Task<Coupon> CreateDiscount([FromBody] Coupon coupon);
}