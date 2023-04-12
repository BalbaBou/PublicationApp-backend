using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PA.Data.Models;

namespace PA.Data.Configurations;

public class MailTokenConfig : IEntityTypeConfiguration<MailToken>
{
    public void Configure(EntityTypeBuilder<MailToken> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.User)
            .WithMany(x => x.Tokens)
            .HasForeignKey(x => x.UserId);
    }
}