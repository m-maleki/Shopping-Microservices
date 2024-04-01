using Shopping.WebApi.Entities;

namespace Shopping.WebApi.Services.Services.AppServices.Contracts;
public interface IProductAppServices
{
    Task<Product> GetBy(int id);
    Task<IEnumerable<Product>> GetAll();
}