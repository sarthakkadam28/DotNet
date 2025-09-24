using Microsoft.EntityFrameworkCore;
using Entity_Framework;

public class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=localhost;port=3306;user=root;password=password;database=assessmentdb");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().ToTable("Students");
        modelBuilder.Entity<Student>().HasKey(s => s.Id);
        modelBuilder.Entity<Student>().Property(s => s.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Student>().Property(s => s.Age).IsRequired();
    }
    
}
