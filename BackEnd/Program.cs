using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using _NET_Office_Management_BackEnd.Models;
using _NET_Office_Management_BackEnd.Repositories;
using _NET_Office_Management_BackEnd.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// MariaDB
var connectionString = builder.Configuration.GetConnectionString("MariaDbConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(dbContextOptions => dbContextOptions
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        // The following three options help with debugging, but should
        // be changed or removed for production.
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

// Repositories
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAssetRepository, AssetRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IRequisitionRepository, RequisitionRepository>();
builder.Services.AddScoped<ILeaveRepository, LeaveRepository>();
builder.Services.AddScoped<ITokenUtil, JWTTokenUtil>();
builder.Services.AddScoped<IAccountUtil, AccountUtil>();
builder.Services.AddScoped<ICommonUtil, CommonUtil>();

// CORS
var  OfficeManagementOrigins = "_officeManagementSpecificOrigins";
// TODO: allow specific origin does not work
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy(name: OfficeManagementOrigins, builder =>
//     {
//         builder.WithOrigins("http://localhost:4200")
//                 .WithMethods("PUT", "POST", "GET")
//                 .WithHeaders("Content-Type", "Authorization");
//     });
// });

// allow all
builder.Services.AddCors(options => options.AddPolicy(OfficeManagementOrigins, builder =>
{
    builder.WithOrigins("*").WithMethods("PUT", "POST", "GET").WithHeaders("Content-Type", "Authorization");
}));

// JWT
var jwtKey = builder.Configuration["JwtKey"];
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
if (jwtKey != null)
{
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(cfg =>
    {
        cfg.RequireHttpsMetadata = false;
        cfg.SaveToken = true;
        cfg.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["JwtIssuer"],
            ValidAudience = builder.Configuration["JwtAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey == null ? "" : jwtKey)),
            ClockSkew = TimeSpan.Zero // remove delay of token when expire
        };
    });
}

var app = builder.Build();

app.UseRouting();

app.UseCors(OfficeManagementOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
