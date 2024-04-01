using Dapper;
using Npgsql;
using DiscountService.WebApi.Entities;
using DiscountService.WebApi.Repositories.Contracts;

namespace DiscountService.WebApi.Repositories.Implementations;
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
        await using var connection = new NpgsqlConnection(_connectionString);

        var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
            (Queries.GetDiscount, new { ProductName = productName });

        return coupon ?? new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };
    }

    public async Task<bool> CreateDiscount(Coupon coupon)
    {
        await using var connection = new NpgsqlConnection(_connectionString);

        var affected =
            await connection.ExecuteAsync
                (Queries.CreateDiscount,
                        new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

        return affected != 0;
    }

    public async Task<bool> UpdateDiscount(Coupon coupon)
    {
        await using var connection = new NpgsqlConnection(_connectionString);

        var affected = await connection.ExecuteAsync
                (Queries.UpdateDiscount,
                        new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id });

        return affected != 0;
    }

    public async Task<bool> DeleteDiscount(string productName)
    {
        await using var connection = new NpgsqlConnection(_connectionString);

        var affected = await connection.ExecuteAsync(Queries.DeleteDiscount,
            new { ProductName = productName });

        return affected != 0;
    }
}
