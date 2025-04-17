using eApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eApp.Data.Mappings;

public class BaseMap<T> : IEntityTypeConfiguration<T> where T : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
        .ValueGeneratedOnAdd();

        builder.Property(x => x.CreatedAt)
        .IsRequired()
        .HasDefaultValueSql("GETDATE()");

        builder.Property(x => x.UpdatedAt)
        .IsRequired()
        .ValueGeneratedOnUpdate();
    }
}