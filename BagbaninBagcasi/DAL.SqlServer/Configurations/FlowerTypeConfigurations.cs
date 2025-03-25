using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace DAL.SqlServer.Configurations;

public class FlowerTypeConfigurations : IEntityTypeConfiguration<FlowerType>
{
    public void Configure(EntityTypeBuilder<FlowerType> builder)
    {
       

        builder.Property(f => f.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(f => f.Color)
            .HasMaxLength(50);

        builder.Property(f => f.Season)
            .HasMaxLength(50);

        builder.Property(f => f.GrowthType)
            .HasMaxLength(50);

        builder.HasMany(f => f.Products)
            .WithOne(p => p.FlowerType)
            .HasForeignKey(p => p.FlowerTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        
    }
}
