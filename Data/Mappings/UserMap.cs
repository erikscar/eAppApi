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
        .IsRequired()
        .HasColumnType("VARCHAR(100)");

        builder.Property(user => user.LastName)
        .IsRequired()
        .HasColumnType("VARCHAR(100)");

        builder.Property(user => user.Email)
        .IsRequired()
        .HasColumnType("VARCHAR(100)");

        builder.Property(user => user.PasswordHash)
        .IsRequired()
        .HasColumnType("VARCHAR(255)");
    }
}