using Logging;
using System.Text;
using Shopping.WebApi.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Shopping.WebApi.Services.Services.Services.Services;
using Shopping.WebApi.Services.Services.Services.Contracts;
using Shopping.WebApi.Services.Services.AppServices.Contracts;
using Shopping.WebApi.Services.Services.AppServices.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSerilog(builder.Configuration);

#region RegisterServices

builder.Services.AddScoped<IAccountServices, AccountServices>();
builder.Services.AddScoped<IBasketAppServices, BasketAppServices>();
builder.Services.AddScoped<IProductAppServices, ProductAppServices>();
builder.Services.AddScoped<IAccountAppServices, AccountAppServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IBasketServices, BasketServices>();

#endregion

#region RegisterDbContext

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=auth.db"));

#endregion

#region Register Identity

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

});

var JWTSetting = builder.Configuration.GetSection("JWTSetting");


builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt => {
    opt.SaveToken = true;
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = JWTSetting["ValidAudience"],
        ValidIssuer = JWTSetting["ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTSetting.GetSection("securityKey").Value!))


    };
});

#endregion

#region RegisterHttpClient

builder.Services.AddHttpClient("Products", client =>
{
    client.BaseAddress = new Uri("https://localhost:7220/");
});

builder.Services.AddHttpClient("Basket", client =>
{
    client.BaseAddress = new Uri("https://localhost:7220/");
});

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseErrorLogging();

app.MapControllers();

app.UseCors(option =>
{
    option.AllowAnyMethod();
    option.AllowAnyHeader();
    option.AllowAnyOrigin();
});

app.Run();
