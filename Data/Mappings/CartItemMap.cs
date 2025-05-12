using eApp.Data.Mappings;
using eApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eApp.Data.Mappings;

public class CartItemMap : BaseMap<CartItem>
{
    public override void Configure(EntityTypeBuilder<CartItem> builder)
    {
        base.Configure(builder);

        builder.Property(cartItem => cartItem.Quantity)
        .IsRequired();

        builder.Property(cartItem => cartItem.Price)
        .HasPrecision(7,2)
        .IsRequired();

        builder.HasOne(cartItem => cartItem.Cart)
        .WithMany(cart => cart.CartItems)
        .HasForeignKey(cartItem => cartItem.CartId);

        builder.HasOne(cartItem => cartItem.Product)
        .WithMany(product => product.CartItems)
        .HasForeignKey(cartItem => cartItem.ProductId);
    }
}