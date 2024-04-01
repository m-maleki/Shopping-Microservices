﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductService.WebApi.DataAccess.EfCore;

#nullable disable

namespace ProductService.WebApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductService.WebApi.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Mobile phones"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Laptops"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Clothing"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Electronics"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Books"
                        },
                        new
                        {
                            Id = 6,
                            Title = "Home Appliances"
                        },
                        new
                        {
                            Id = 7,
                            Title = "Cosmetics"
                        },
                        new
                        {
                            Id = 8,
                            Title = "Furniture"
                        },
                        new
                        {
                            Id = 9,
                            Title = "Sporting Goods"
                        },
                        new
                        {
                            Id = 10,
                            Title = "Toys"
                        });
                });

            modelBuilder.Entity("ProductService.WebApi.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Smartphone",
                            Price = 599.99m,
                            Summary = "A high-quality smartphone"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Laptop",
                            Price = 1099.99m,
                            Summary = "A powerful laptop"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "T-Shirt",
                            Price = 19.99m,
                            Summary = "Comfortable t-shirt"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Smart TV",
                            Price = 799.99m,
                            Summary = "High-definition smart TV"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 5,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Novel",
                            Price = 14.99m,
                            Summary = "Best-selling novel"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 6,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Refrigerator",
                            Price = 899.99m,
                            Summary = "Energy-efficient refrigerator"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 7,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Lipstick",
                            Price = 9.99m,
                            Summary = "Long-lasting lipstick"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 8,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Sofa",
                            Price = 499.99m,
                            Summary = "Comfortable sofa"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 9,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Yoga Mat",
                            Price = 29.99m,
                            Summary = "High-quality yoga mat"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 10,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Action Figure",
                            Price = 24.99m,
                            Summary = "Collectible action figure"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 1,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Headphones",
                            Price = 79.99m,
                            Summary = "High-quality headphones"
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 1,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Tablet",
                            Price = 299.99m,
                            Summary = "Portable tablet"
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 1,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Desktop Computer",
                            Price = 1299.99m,
                            Summary = "Powerful desktop computer"
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 3,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Dress Shirt",
                            Price = 29.99m,
                            Summary = "Stylish dress shirt"
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 3,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Jeans",
                            Price = 39.99m,
                            Summary = "Classic jeans"
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 4,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Camera",
                            Price = 699.99m,
                            Summary = "Professional camera"
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 4,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Speaker System",
                            Price = 499.99m,
                            Summary = "Premium speaker system"
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 9,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Running Shoes",
                            Price = 59.99m,
                            Summary = "Comfortable running shoes"
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 9,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Basketball",
                            Price = 24.99m,
                            Summary = "Official basketball"
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 10,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            Name = "Action Figure",
                            Price = 12.99m,
                            Summary = "Collectible action figure"
                        });
                });

            modelBuilder.Entity("ProductService.WebApi.Entities.Product", b =>
                {
                    b.HasOne("ProductService.WebApi.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}