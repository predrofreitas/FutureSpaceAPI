using FutureSpaceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FutureSpaceAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Launcher> Launchers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Launcher>()
                .HasKey(l => l.LaunchId);
        }
    }
}