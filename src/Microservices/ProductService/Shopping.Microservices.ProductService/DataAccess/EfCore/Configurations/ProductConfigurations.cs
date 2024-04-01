using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.WebApi.Entities;

namespace ProductService.WebApi.DataAccess.EfCore.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);

        builder.HasData(new List<Product>
        {
            new Product()
            {
                Id = 1, Name = "Smartphone", Summary = "A high-quality smartphone",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 599.99m,
                CategoryId = 1
            },
            new Product()
            {
                Id = 2, Name = "Laptop", Summary = "A powerful laptop",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 1099.99m,
                CategoryId = 2
            },
            new Product()
            {
                Id = 3, Name = "T-Shirt", Summary = "Comfortable t-shirt",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 19.99m,
                CategoryId = 3
            },
            new Product()
            {
                Id = 4, Name = "Smart TV", Summary = "High-definition smart TV",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 799.99m,
                CategoryId = 4
            },
            new Product()
            {
                Id = 5, Name = "Novel", Summary = "Best-selling novel",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 14.99m,
                CategoryId = 5
            },
            new Product()
            {
                Id = 6, Name = "Refrigerator", Summary = "Energy-efficient refrigerator",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 899.99m,
                CategoryId = 6
            },
            new Product()
            {
                Id = 7, Name = "Lipstick", Summary = "Long-lasting lipstick",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 9.99m,
                CategoryId = 7
            },
            new Product()
            {
                Id = 8, Name = "Sofa", Summary = "Comfortable sofa",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 499.99m,
                CategoryId = 8
            },
            new Product()
            {
                Id = 9, Name = "Yoga Mat", Summary = "High-quality yoga mat",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 29.99m,
                CategoryId = 9
            },
            new Product()
            {
                Id = 10, Name = "Action Figure", Summary = "Collectible action figure",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 24.99m,
                CategoryId = 10
            },
            new Product()
            {
                Id = 11,
                Name = "Headphones", Summary = "High-quality headphones",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 79.99m,
                CategoryId = 1
            },
            new Product()
            {
                Id = 12, Name = "Tablet", Summary = "Portable tablet",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 299.99m,
                CategoryId = 1
            },
            new Product()
            {
                Id = 13, Name = "Desktop Computer", Summary = "Powerful desktop computer",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 1299.99m,
                CategoryId = 1
            },
            new Product()
            {
                Id = 14, Name = "Dress Shirt", Summary = "Stylish dress shirt",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 29.99m,
                CategoryId = 3
            },
            new Product()
            {
                Id = 15, Name = "Jeans", Summary = "Classic jeans",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 39.99m,
                CategoryId = 3
            },
            new Product()
            {
                Id = 16, Name = "Camera", Summary = "Professional camera",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 699.99m,
                CategoryId = 4
            },
            new Product()
            {
                Id = 17, Name = "Speaker System", Summary = "Premium speaker system",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 499.99m,
                CategoryId = 4
            },
            new Product()
            {
                Id = 18, Name = "Running Shoes", Summary = "Comfortable running shoes",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 59.99m,
                CategoryId = 9
            },
            new Product()
            {
                Id = 19, Name = "Basketball", Summary = "Official basketball",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 24.99m,
                CategoryId = 9
            },
            new Product()
            {
                Id = 20, Name = "Action Figure", Summary = "Collectible action figure",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Price = 12.99m,
                CategoryId = 10
            }
        });
    }
}
