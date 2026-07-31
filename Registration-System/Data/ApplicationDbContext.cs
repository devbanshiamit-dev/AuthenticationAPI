using Microsoft.EntityFrameworkCore;
using Registration_System.Models;

namespace Registration_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}
