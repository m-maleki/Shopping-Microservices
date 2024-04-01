using Microsoft.AspNetCore.Mvc;
using ProductService.WebApi.Entities;
using ProductService.WebApi.Services.Contracts;

namespace ProductService.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        [Route(nameof(GetProducts))]
        public async Task<IActionResult> GetProducts()
            => Ok(await _productServices.GetProducts());

        [HttpGet]
        [Route(nameof(GetProductById))]
        public async Task<IActionResult> GetProductById(int id)
            => Ok(await _productServices.GetProductById(id));

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult> Create(Product product)
            => Ok(await _productServices.Create(product));

        [HttpDelete]
        [Route(nameof(DeleteProduct))]
        public async Task DeleteProduct(int id)
            => await _productServices.DeleteProduct(id);
    }
}
