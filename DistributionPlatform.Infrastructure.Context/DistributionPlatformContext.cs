using DistributionPlatform.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace DistributionPlatform.Infrastructure.Context
{
    public class DistributionPlatformContext : DbContext
    {
        public virtual DbSet<Application> Applications { get; set; }
        public DistributionPlatformContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
