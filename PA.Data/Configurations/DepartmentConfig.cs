//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PA.Data.Models;

namespace PA.Data.Configurations;

public class DepartmentConfig //: IEntityTypeConfiguration<Department>
{
    public DepartmentConfig(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Faculty)
            .WithMany(x => x.Departments)
            .HasForeignKey(x => x.FacultyId);
    }
    /*public void Configure(EntityTypeBuilder<Department> departmentBuilder)
    {
        departmentBuilder.HasKey(x => x.Id);
        departmentBuilder.HasOne(x => x.Faculty)
            .WithMany(x => x.Departments)
            .HasForeignKey(x => x.FacultyId);
    }*/
}