using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.WebApi.Entities;

namespace ProductService.WebApi.DataAccess.EfCore.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(50);

            builder.HasData(new List<Category>()
            {
                new Category() { Id = 1, Title = "Mobile phones" },
                new Category() { Id = 2, Title = "Laptops" },
                new Category() { Id = 3, Title = "Clothing" },
                new Category() { Id = 4, Title = "Electronics" },
                new Category() { Id = 5, Title = "Books" },
                new Category() { Id = 6, Title = "Home Appliances" },
                new Category() { Id = 7, Title = "Cosmetics" },
                new Category() { Id = 8, Title = "Furniture" },
                new Category() { Id = 9, Title = "Sporting Goods" },
                new Category() { Id = 10, Title = "Toys" }
            });
        }
    }
}
