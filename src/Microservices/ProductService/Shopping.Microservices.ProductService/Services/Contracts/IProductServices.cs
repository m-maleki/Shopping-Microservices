using ProductService.WebApi.Entities;

namespace ProductService.WebApi.Services.Contracts;

public interface IProductServices
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProductById(int id);
    Task<int> Create(Product product);
    Task DeleteProduct(int id);
}