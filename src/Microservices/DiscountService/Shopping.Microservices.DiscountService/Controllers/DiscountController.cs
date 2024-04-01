using Microsoft.AspNetCore.Mvc;
using DiscountService.WebApi.Entities;
using DiscountService.WebApi.Services.Contracts;

namespace DiscountService.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountServices _discountServices;

        public DiscountController(IDiscountServices discountServices)
        {
            _discountServices = discountServices;
        }

        [Route(nameof(GetDiscount))]
        [HttpGet]
        public async Task<ActionResult<Coupon>> GetDiscount(string productName)
            => Ok(await _discountServices.GetDiscount(productName));

        [Route(nameof(CreateDiscount))]
        [HttpPost]
        public async Task<ActionResult<Coupon>> CreateDiscount([FromBody] Coupon coupon)
            => Ok(await _discountServices.CreateDiscount(coupon));
    }
}
