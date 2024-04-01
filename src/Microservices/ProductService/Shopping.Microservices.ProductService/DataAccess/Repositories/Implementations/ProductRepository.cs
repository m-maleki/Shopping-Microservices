using Microsoft.EntityFrameworkCore;
using ProductService.WebApi.Entities;
using ProductService.WebApi.DataAccess.EfCore;
using ProductService.WebApi.DataAccess.Repositories.Contracts;

namespace ProductService.WebApi.DataAccess.Repositories.Implementations;
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _appDbContext;

    public ProductRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }


    public async Task<int> Create(Product model)
    {
        await _appDbContext.Products
            .AddAsync(model);

        await _appDbContext.SaveChangesAsync();

        return model.Id;
    }
    public async Task<Product> GetBy(int id)
    {
        var product = await _appDbContext.Products
            .FirstOrDefaultAsync(x => x.Id == id);

        if (product is { })
        {
            return product;
        }
        else
        {
            throw new Exception($"Product id : {id} not found");
        }
    }
    public async Task<IEnumerable<Product>> GetAll()
        => await _appDbContext.Products
            .ToListAsync();

    public async Task Delete(int id)
    {
        var product = await _appDbContext.Products
            .FirstOrDefaultAsync(x => x.Id == id);

        if (product is { })
        {
            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();
        }
        else
        {
            throw new Exception($"Product id : {id} not found");
        }
    }
}
