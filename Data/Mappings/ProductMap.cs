using eApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eApp.Data.Mappings;

public class ProductMap : BaseMap<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {

        base.Configure(builder);

        builder.Property(product => product.Name)
        .IsRequired()
        .HasColumnType("VARCHAR(100)");

        builder.Property(product => product.Description)
        .IsRequired()
        .HasColumnType("VARCHAR(255)");

        builder.Property(product => product.Price)
        .IsRequired()
        .HasPrecision(7, 2);

        builder.Property(product => product.Offer)
        .HasDefaultValue(0);

        builder.Property(product => product.CategoryId)
        .IsRequired();

        builder.HasOne(product => product.Category)
        .WithMany(category => category.Products)
        .HasForeignKey(product => product.CategoryId);
    }
}