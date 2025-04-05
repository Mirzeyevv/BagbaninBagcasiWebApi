using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using Domain.Enums;

namespace DAL.SqlServer.Configurations;

public class FlowerTypeConfigurations : IEntityTypeConfiguration<FlowerType>
{
    public void Configure(EntityTypeBuilder<FlowerType> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(f => f.Color)
            .HasMaxLength(50);

        builder.HasMany(f => f.Products)
            .WithOne(p => p.FlowerType)
            .HasForeignKey(p => p.FlowerTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(f => f.Seasons)
           .HasConversion(
               v => string.Join(",", v),
               v => v.Split(",", StringSplitOptions.RemoveEmptyEntries)
                     .Select(s => Enum.Parse<Season>(s))
                     .ToList()
           );

        builder.Property(f => f.GrowthTypes)
            .HasConversion(
                v => string.Join(",", v),
                v => v.Split(",", StringSplitOptions.RemoveEmptyEntries)
                      .Select(s => Enum.Parse<GrowthType>(s))
                      .ToList()
            );

        builder.ToTable("FlowerTypes");
    }
}


