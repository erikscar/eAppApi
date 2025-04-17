using eApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eApp.Data.Mappings;

public class CategoryMap : BaseMap<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);
       
        builder.Property(category => category.Name)
        .IsRequired()
        .HasColumnType("VARCHAR(100)");

        builder.Property(category => category.Description)
        .IsRequired()
        .HasColumnType("VARCHAR(255)");
    }
}