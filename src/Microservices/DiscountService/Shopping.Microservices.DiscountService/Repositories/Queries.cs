namespace DiscountService.WebApi.Repositories;
public static class Queries
{
    public const string GetDiscount = "SELECT * FROM coupons WHERE productName  = @ProductName";

    public const string CreateDiscount =
        "INSERT INTO coupons (ProductName , Description , Amount) VALUES (@ProductName, @Description, @Amount)";

    public const string UpdateDiscount =
        "UPDATE coupons SET productName=@ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id";

    public const string DeleteDiscount = "DELETE FROM coupons WHERE ProductName = @ProductName";


}