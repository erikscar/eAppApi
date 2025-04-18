using eApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eApp.Data.Mappings;

public class CartMap : BaseMap<Cart>
{
    public override void Configure(EntityTypeBuilder<Cart> builder)
    {
        base.Configure(builder);

        builder.Property(cart => cart.Price)
        .HasPrecision(7, 2);

        builder.Property(cart => cart.UserId)
        .IsRequired();

        builder.HasMany(cart => cart.Products)
        .WithMany(product => product.Carts)
        .UsingEntity(x => x.ToTable("Cart_Product"));
    }
}