using AztroWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AztroWebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User").HasKey(u => u.Id);

            modelBuilder.Entity<User>()
            .Property(u => u.Id).HasColumnName("id");

            modelBuilder.Entity<User>()
            .Property(u => u.Name).HasColumnName("name");

            modelBuilder.Entity<User>()
            .Property(u => u.Email).HasColumnName("email");

            modelBuilder.Entity<User>()
            .Property(u => u.Age).HasColumnName("age");
        }
    }
}