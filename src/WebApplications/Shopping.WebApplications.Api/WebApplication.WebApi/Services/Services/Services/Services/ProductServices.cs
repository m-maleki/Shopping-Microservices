using Shopping.WebApi.Entities;
using Shopping.WebApi.Services.Services.Services.Contracts;

namespace Shopping.WebApi.Services.Services.Services.Services;
public class ProductServices : IProductServices
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductServices(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Product> GetBy(int id)
    {
        using var client = _httpClientFactory.CreateClient("Products");

        var response = await client.GetStringAsync($"api/v1/Products/GetProductById?id={id}");

        return response.ConvertToObject<Product>();
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        using var client = _httpClientFactory.CreateClient("Products");

        var response = await client.GetStringAsync($"api/v1/Products/GetProducts");

        return response.ConvertToObject<List<Product>>();
    }
}