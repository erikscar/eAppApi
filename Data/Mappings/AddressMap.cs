using eApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eApp.Data.Mappings
{
    public class AddressMap : BaseMap<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);

            builder.Property(address => address.Street)
            .HasColumnType("VARCHAR(100)");

            builder.Property(address => address.Number)
            .HasColumnType("VARCHAR(10)");

            builder.Property(address => address.Complement)
            .HasColumnType("VARCHAR(50)");

            builder.Property(address => address.Neighborhood)
            .HasColumnType("VARCHAR(50)");

            builder.Property(address => address.City)
            .HasColumnType("VARCHAR(50)");

            builder.Property(address => address.PostalCode)
            .HasColumnType("VARCHAR(20)");


        }
    }
}
