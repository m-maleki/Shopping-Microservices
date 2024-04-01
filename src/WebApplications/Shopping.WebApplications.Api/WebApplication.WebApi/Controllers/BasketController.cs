using Microsoft.AspNetCore.Mvc;
using Shopping.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Shopping.WebApi.Services.Services.AppServices.Contracts;

namespace Shopping.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    [ApiResultFilter]
    public class BasketController : ControllerBase
    {
        private readonly IBasketAppServices _basketAppServices;

        public BasketController(IBasketAppServices basketAppServices)
        {
            _basketAppServices = basketAppServices;
        }

        [HttpGet]
        [Route(nameof(GetBasket))]
        public async Task<IActionResult> GetBasket()
            => Ok(await _basketAppServices.GetBasket(User.Identity!.Name!));


        [HttpGet]
        [Route(nameof(AddToBasket))]
        public async Task AddToBasket(int productId)
           => await _basketAppServices.UpdateBasket(User.Identity!.Name!, productId);

        [HttpGet]
        [Route(nameof(RemoveItemFromBasket))]
        public async Task RemoveItemFromBasket(int productId)
            => await _basketAppServices.RemoveItemFromBasket(User.Identity!.Name!, productId);
    }
}
