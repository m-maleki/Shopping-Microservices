using Microsoft.AspNetCore.Mvc;
using BasketService.WebApi.Entities;
using BasketService.WebApi.Services.Implementations;

namespace BasketService.WebApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class BasketController : ControllerBase
{

    private readonly IBasketServices _basketServices;

    public BasketController(IBasketServices basketServices)
    {
        _basketServices = basketServices;
    }

    [HttpPost]
    [Route(nameof(UpdateBasket))]
    public async Task<ActionResult> UpdateBasket([FromBody] ShoppingCart basket)
        => Ok(_basketServices.UpdateBasket(basket)); 

    [HttpGet]
    [Route(nameof(GetBasket))]
    public async Task<ActionResult> GetBasket(string userName)
        => Ok(await _basketServices.GetBasket(userName));
}
