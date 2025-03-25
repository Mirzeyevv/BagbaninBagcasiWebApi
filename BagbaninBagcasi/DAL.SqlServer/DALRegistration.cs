using DAL.SqlServer.Context;
using DAL.SqlServer.Repositories.Abstractions;
using DAL.SqlServer.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DAL.SqlServer;

public static class DALRegistration
{

    public static void RegisterDAL(this IServiceCollection service, IConfiguration configuration)
    {

        service.AddDbContext<AppDbContext>(opt =>
        {

            opt.UseSqlServer(configuration.GetConnectionString("MSSql"));
            
        });

        service.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        service.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

        service.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        service.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

        service.AddScoped<IDebtReadRepository, DebtReadRepository>();
        service.AddScoped<IDebtWriteRepository, DebtWriteRepository>();

        service.AddScoped<IExpenseReadRepository, ExpenseReadRepository>();
        service.AddScoped<IExpenseWriteRepository, ExpenseWriteRepository>();

        service.AddScoped<IExpenseTypeReadRepository, ExpenseTypeReadRepository>();
        service.AddScoped<IExpenseTypeWriteRepository, ExpenseTypeWriteRepository>();

        service.AddScoped<IFlowerTypeReadRepository, FlowerTypeReadRepository>();
        service.AddScoped<IFlowerTypeWriteRepository, FlowerTypeWriteRepository>();

        service.AddScoped<IProductReadRepository, ProductReadRepository>();
        service.AddScoped<IProductWriteRepository, ProductWriteRepository>();

        service.AddScoped<ISaleReadRepository, SaleReadRepository>();
        service.AddScoped<ISaleWriteRepository, SaleWriteRepository>();

        service.AddScoped<ISaleProductReadRepository, SaleProductReadRepository>();
        service.AddScoped<ISaleProductWriteRepository, SaleProductWriteRepository>();

    }

}
