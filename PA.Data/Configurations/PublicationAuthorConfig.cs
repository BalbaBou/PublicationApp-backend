using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PA.Data.Models;

namespace PA.Data.Configurations;

public class PublicationAuthorConfig : IEntityTypeConfiguration<PublicationAuthor>
{
    public void Configure(EntityTypeBuilder<PublicationAuthor> builder)
    {
        builder.HasKey(x => new {x.AuthorId, x.PublicationId});

        builder
            .HasOne(x => x.Author)
            .WithMany(x => x.Publications)
            .HasForeignKey(x => x.AuthorId)
            .IsRequired(true);

        builder
            .HasOne(x => x.Publication)
            .WithMany(x => x.Authors)
            .HasForeignKey(x => x.PublicationId)
            .IsRequired(true);
    }
}