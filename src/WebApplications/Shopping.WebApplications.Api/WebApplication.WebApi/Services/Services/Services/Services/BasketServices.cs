using System.Net;
using System.Text;
using Newtonsoft.Json;
using Shopping.WebApi.Entities;
using Shopping.WebApi.Services.Services.Services.Contracts;

namespace Shopping.WebApi.Services.Services.Services.Services;
public class BasketServices : IBasketServices
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BasketServices(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<BasketModel> GetBasket(string userName)
    {
        using var client = _httpClientFactory.CreateClient("Basket");

        var response = await client.GetStringAsync($"Api/v1/Basket/GetBasket?userName={userName}");

        if (string.IsNullOrEmpty(response))
        {
            new BasketModel() { UserName = userName };
        }

        return response.ConvertToObject<BasketModel>();

    }

    public async Task<bool> UpdateBasket(BasketModel model)
    {
        using var client = _httpClientFactory.CreateClient("Basket");

        var json = JsonConvert.SerializeObject(model);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await client.PostAsync($"Api/v1/Basket/UpdateBasket", content);

        return true;
    }
}