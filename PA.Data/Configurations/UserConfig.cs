using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PA.Data.Models;

namespace PA.Data.Configurations;

public class UserConfig
{
    public UserConfig(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(t => t.Id);
    }
}