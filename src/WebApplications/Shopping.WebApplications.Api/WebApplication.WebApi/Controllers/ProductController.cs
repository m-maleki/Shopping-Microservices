using Microsoft.AspNetCore.Mvc;
using Shopping.WebApi.Entities;
using Shopping.WebApi.Extensions;
using Shopping.WebApi.Services.Services.AppServices.Contracts;

namespace Shopping.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiResultFilter]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppServices _productAppServices;

        public ProductController(IProductAppServices productAppServices)
        {
            _productAppServices = productAppServices;
        }

        [HttpGet]
        [Route(nameof(GetProducts))]
        public async Task<IActionResult> GetProducts()
           => Ok(await _productAppServices.GetAll());


        [HttpGet]
        [Route(nameof(GetById))]
        public async Task<Product> GetById(int productId)
            => await _productAppServices.GetBy(productId);
    }
}
