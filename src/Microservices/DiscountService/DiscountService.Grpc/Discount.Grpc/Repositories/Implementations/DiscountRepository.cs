using Dapper;
using Npgsql;
using Discount.Grpc.Entities;

namespace Discount.Grpc.Repositories.Contracts;
public class DiscountRepository : IDiscountRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DiscountRepository(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _connectionString = _configuration.GetValue<string>("DatabaseSettings:DefaultConnection");
    }

    public async Task<Coupon> GetDiscount(string productName)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
            ("SELECT * FROM coupons WHERE productName  = @ProductName", new { ProductName = productName });

        if (coupon == null)
            return new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };
        return coupon;
    }

    public async Task<bool> CreateDiscount(Coupon coupon)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        var affected =
            await connection.ExecuteAsync
                ("INSERT INTO coupons (ProductName , Description , Amount) VALUES (@ProductName, @Description, @Amount)",
                        new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

        if (affected == 0)
            return false;

        return true;
    }

    public async Task<bool> UpdateDiscount(Coupon coupon)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        var affected = await connection.ExecuteAsync
                ("UPDATE coupons SET productName=@ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id",
                        new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id });

        if (affected == 0)
            return false;

        return true;
    }

    public async Task<bool> DeleteDiscount(string productName)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        var affected = await connection.ExecuteAsync("DELETE FROM coupons WHERE ProductName = @ProductName",
            new { ProductName = productName });

        if (affected == 0)
            return false;

        return true;
    }
}
