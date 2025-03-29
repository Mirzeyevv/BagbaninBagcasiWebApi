using BusinessLayer.ExternalServices.Abstractions;
using BusinessLayer.ExternalServices.Implementations;
using BusinessLayer.Profiles.CategoryProfiles;
using BusinessLayer.Services.Abstractions;
using BusinessLayer.Services.Implementations;
using DAL.SqlServer.Context;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer;

public static class BLRegistration
{
    public static void AddBlServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddAutoMapper(typeof(CategoryProfile).Assembly);
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        services.AddScoped<IFileUploadService, FileUploadService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IDebtService, DebtService>();
        services.AddScoped<IExpenseService, ExpenseService>();
        services.AddScoped<IExpenseTypeService, ExpenseTypeService>();
        services.AddScoped<IFlowerTypeService, FlowerTypeService>();
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ISaleProductService, SaleProductService>();
        services.AddScoped<ISaleService, SaleService>();


        services.AddAuthentication(cfg => {
            cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x => {

            x.TokenValidationParameters = new TokenValidationParameters
            {

                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8
                        .GetBytes(configuration["Jwt:SecretKey"])
                ),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = configuration["Jwt:Audience"],
                ValidIssuer = configuration["Jwt:Issuer"]
            };
        });

        services.AddIdentity<IdentityUser, IdentityRole>(opt =>
        {
            {
                opt.Password.RequiredLength = 8;
                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                opt.Lockout.MaxFailedAccessAttempts = 4;
            }
        }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();


    }


}
