using Shopping.WebApi.Entities;

namespace Shopping.WebApi.Services.Services.Services.Contracts;

public interface IProductServices
{
    Task<Product> GetBy(int id);
    Task<IEnumerable<Product>> GetAll();
}