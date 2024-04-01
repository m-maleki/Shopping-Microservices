using ProductService.WebApi.Entities;

namespace ProductService.WebApi.DataAccess.Repositories.Contracts;
public interface IProductRepository
{
    Task<int> Create(Product model);
    Task<Product> GetBy(int id);
    Task<IEnumerable<Product>> GetAll();
    Task Delete(int id);
}
