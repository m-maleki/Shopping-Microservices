using ProductService.WebApi.Entities;
using ProductService.WebApi.Services.Contracts;
using ProductService.WebApi.DataAccess.Repositories.Contracts;

namespace ProductService.WebApi.Services.Implementations;
public class ProductServices : IProductServices
{
    private readonly IProductRepository _productRepository;

    public ProductServices(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> GetProducts()
        => await _productRepository.GetAll();

    public async Task<Product> GetProductById(int id)
        => await _productRepository.GetBy(id);

    public async Task<int> Create(Product product)
        => await _productRepository.Create(product);

    public async Task DeleteProduct(int id)
        => await _productRepository.Delete(id);
}