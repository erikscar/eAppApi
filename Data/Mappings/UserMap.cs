using eApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eApp.Data.Mappings;

public class UserMap : BaseMap<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        
        builder.Property(user => user.FirstName)
        .HasColumnType("VARCHAR(100)");

        builder.Property(user => user.LastName)
        .HasColumnType("VARCHAR(100)");

        builder.Property(user => user.Email)
        .IsRequired()
        .HasColumnType("VARCHAR(100)");

        builder.Property(user => user.PasswordHash)
        .IsRequired()
        .HasColumnType("VARCHAR(255)");

        builder.HasOne(user => user.Cart)
        .WithOne(cart => cart.User)
        .HasForeignKey<Cart>(cart => cart.UserId)
        .IsRequired();

        builder.HasMany(user => user.Addresses)
        .WithOne(address => address.User)
        .HasForeignKey(address => address.UserId)
        .IsRequired();
    }
}