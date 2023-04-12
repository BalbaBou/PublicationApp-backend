//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PA.Data.Models;

namespace PA.Data.Configurations;

public class FacultyConfig //: IEntityTypeConfiguration<Faculty>
{
    public FacultyConfig(EntityTypeBuilder<Faculty> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
