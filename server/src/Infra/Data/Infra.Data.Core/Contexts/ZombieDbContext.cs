using Domain.Zombie.Resources.Models;
using Infra.Data.Core.Mappings.Resources;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Core.Contexts
{
    public class ZombieDbContext : DbContext
    {
        public ZombieDbContext(DbContextOptions<ZombieDbContext> options)
        : base(options) { }

        public DbSet<ResourceRoot> Resources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ResourceRootMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}