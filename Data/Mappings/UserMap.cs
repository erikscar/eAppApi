using eApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eApp.Data.Mappings;

public class UserMap : BaseMap<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(user => user.FirstName).HasColumnType("VARCHAR(100)");

        builder.Property(user => user.LastName).HasColumnType("VARCHAR(100)");

        builder.Property(user => user.Email).IsRequired().HasColumnType("VARCHAR(100)");

        builder.Property(user => user.Phone).HasColumnType("VARCHAR(50)");

        builder.Property(user => user.ImageUrl).HasColumnType("VARCHAR(255)");

        builder.Property(user => user.PasswordHash).IsRequired().HasColumnType("VARCHAR(255)");

        builder
            .HasOne(user => user.Cart)
            .WithOne(cart => cart.User)
            .HasForeignKey<Cart>(cart => cart.UserId)
            .IsRequired();

        builder.HasData(
            new User
            {
                Id = 1,
                FirstName = "Master",
                LastName = "Admin",
                Role = "Admin",
                Phone = "(00) 00000-0000",
                ImageUrl = "https://cdn-icons-png.flaticon.com/512/17003/17003310.png",
                Email = "admin@gmail.com",
                PasswordHash = "123",
            }
        );
    }
}
