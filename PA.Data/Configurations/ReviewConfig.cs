using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PA.Data.Models;

namespace PA.Data.Configurations;

public class ReviewConfig : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Publication)
            .WithMany(x => x.Reviews)
            .HasForeignKey(x => x.PublicationId)
            .IsRequired(false);
    } 
}