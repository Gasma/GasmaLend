using gasmaTools.Domain.Entities;
using gasmaTools.Infra.Data.EntityConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gasmaTools.Infra.Data.Context
{
    public class GasmaToolsContext : IdentityDbContext
    {
        public GasmaToolsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Game> Game { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<AppUser> AppUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
