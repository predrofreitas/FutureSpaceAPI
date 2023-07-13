using FutureSpaceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FutureSpaceAPI.Data.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options) { } 
    
        public DbSet<Launch> Launches { get; set; } 
        public DbSet<LaunchServiceProvider> LaunchServiceProviders { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pad> Pads { get; set; }
        public DbSet<Rocket> Rockets { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
