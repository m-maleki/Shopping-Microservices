using Microsoft.EntityFrameworkCore;
using ProductService.WebApi.DataAccess.EfCore.Configurations;
using ProductService.WebApi.Entities;

namespace ProductService.WebApi.DataAccess.EfCore;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfigurations());
        modelBuilder.ApplyConfiguration(new ProductConfigurations());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}