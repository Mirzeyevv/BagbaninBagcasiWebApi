using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SqlServer.Context;

public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{

    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<FlowerType> FlowerTypes { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleProduct> SaleProducts { get; set; }
    public DbSet<Debt> Debts { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<ExpenseType> ExpenseTypes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "6d16558a-ba79-4fb5-9717-bd333cfc2b0d", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "287f30c4-6d0f-4687-b117-49d 810376603", Name = "Worker", NormalizedName = "WORKER" }
        );


        IdentityUser admin = new()
        {
            Id = "c10c9801-9957-4018-8e48-0c7812d47b50",
            UserName = "admin",
            NormalizedUserName = "ADMIN"
        };

        PasswordHasher<IdentityUser> hasher = new();
        admin.PasswordHash = hasher.HashPassword(admin, "admin123");

        builder.Entity<IdentityUser>().HasData(admin);

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = admin.Id, RoleId = "6d16558a-ba79-4fb5-9717-bd333cfc2b0d" }
        );

        base.OnModelCreating(builder);
    }


}
