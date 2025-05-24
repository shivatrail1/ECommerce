
using ECommerce.Service.Context;
using ECommerce.Service.Mappers;
using ECommerce.Service.Services;
using ECommerce.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ECommerce.Service.Repository.Interfaces;
using ECommerce.Service.Repository;

namespace ECommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = builder.Configuration;

            // Configure services and middleware for the application.
            // Add services to the container.
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ILogRepository, LogRepository>();
            builder.Services.AddScoped<ILogService, LogService>();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<LoggingDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = config["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
                    };
                });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }
    }
}
