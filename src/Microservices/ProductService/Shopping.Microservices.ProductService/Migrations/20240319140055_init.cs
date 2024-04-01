using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductService.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Mobile phones" },
                    { 2, "Laptops" },
                    { 3, "Clothing" },
                    { 4, "Electronics" },
                    { 5, "Books" },
                    { 6, "Home Appliances" },
                    { 7, "Cosmetics" },
                    { 8, "Furniture" },
                    { 9, "Sporting Goods" },
                    { 10, "Toys" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Summary" },
                values: new object[,]
                {
                    { 1, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Smartphone", 599.99m, "A high-quality smartphone" },
                    { 2, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Laptop", 1099.99m, "A powerful laptop" },
                    { 3, 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "T-Shirt", 19.99m, "Comfortable t-shirt" },
                    { 4, 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Smart TV", 799.99m, "High-definition smart TV" },
                    { 5, 5, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Novel", 14.99m, "Best-selling novel" },
                    { 6, 6, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Refrigerator", 899.99m, "Energy-efficient refrigerator" },
                    { 7, 7, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Lipstick", 9.99m, "Long-lasting lipstick" },
                    { 8, 8, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Sofa", 499.99m, "Comfortable sofa" },
                    { 9, 9, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Yoga Mat", 29.99m, "High-quality yoga mat" },
                    { 10, 10, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Action Figure", 24.99m, "Collectible action figure" },
                    { 11, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Headphones", 79.99m, "High-quality headphones" },
                    { 12, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Tablet", 299.99m, "Portable tablet" },
                    { 13, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Desktop Computer", 1299.99m, "Powerful desktop computer" },
                    { 14, 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Dress Shirt", 29.99m, "Stylish dress shirt" },
                    { 15, 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Jeans", 39.99m, "Classic jeans" },
                    { 16, 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Camera", 699.99m, "Professional camera" },
                    { 17, 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Speaker System", 499.99m, "Premium speaker system" },
                    { 18, 9, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Running Shoes", 59.99m, "Comfortable running shoes" },
                    { 19, 9, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Basketball", 24.99m, "Official basketball" },
                    { 20, 10, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Action Figure", 12.99m, "Collectible action figure" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
