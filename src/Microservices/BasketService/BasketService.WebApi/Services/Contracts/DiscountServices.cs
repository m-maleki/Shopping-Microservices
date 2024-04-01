using BasketService.WebApi.Entities;
using BasketService.WebApi.Services.Implementations;
using Utility;

namespace BasketService.WebApi.Services.Contracts;
public class DiscountServices : IDiscountServices
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DiscountServices(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Coupon> GetDiscount(string productName)
    {
        using var client = _httpClientFactory.CreateClient("Discount");

        var response = await client.GetStringAsync($"/api/v1/Discount/GetDiscount?productName={productName}");

        return response.ConvertToObject<Coupon>();
    }
}
