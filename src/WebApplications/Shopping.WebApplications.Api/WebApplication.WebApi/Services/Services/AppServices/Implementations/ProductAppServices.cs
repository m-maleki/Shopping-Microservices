using Shopping.WebApi.Entities;
using Shopping.WebApi.Services.Services.AppServices.Contracts;
using Shopping.WebApi.Services.Services.Services.Contracts;

namespace Shopping.WebApi.Services.Services.AppServices.Implementations;

public class ProductAppServices : IProductAppServices
{
    private readonly IProductServices _productServices;

    public ProductAppServices(IProductServices productServices)
    {
        _productServices = productServices;
    }

    public async Task<Product> GetBy(int id)
        => await _productServices.GetBy(id);


    public async Task<IEnumerable<Product>> GetAll()
        => await _productServices.GetAll();

}