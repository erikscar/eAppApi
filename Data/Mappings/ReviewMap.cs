using eApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eApp.Data.Mappings
{
    public class ReviewMap : BaseMap<Review>
    {
        public override void Configure(EntityTypeBuilder<Review> builder)
        {
            base.Configure(builder);

            builder.Property(review => review.Content)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder.Property(review => review.Rating)
                .IsRequired();

            builder.HasOne(review => review.Product)
                .WithMany(product => product.Reviews)
                .HasForeignKey(review => review.ProductId)
                .IsRequired();
        }
    }
}
