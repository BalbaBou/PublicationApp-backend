using Microsoft.EntityFrameworkCore;
//using File = PublicationApp.Data.Models.File;
using PA.Data.Models;
using PA.Data.Configurations;
using File = PA.Data.Models.File;

namespace PA.Data;

public class DataContext : DbContext
{
    /*public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        //Database.Migrate();    
    }*/
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database = P ; Username=postgres; Password=3215");

    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<MailToken> MailTokens { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<Publication> Publications { get; set; }
    public DbSet<PublicationAuthor> PublicationAuthor { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Reviewer> Reviewers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder model)
    {
        /*new FacultyConfig(model.Entity<Faculty>());
        new DepartmentConfig(model.Entity<Department>());
        new UserConfig(model.Entity<User>());
        new MailTokenConfig(model.Entity<MailToken>());
        */
        base.OnModelCreating(model);
        model.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
    //dotnet tool install --global dotnet-ef
    //dotnet ef migrations add 'название'
    //dotnet ef database update
}