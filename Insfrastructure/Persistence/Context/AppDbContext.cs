using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //public DbSet<RolesAplicacionesEntity> RolesAplicaciones => Set<RolesAplicacionesEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            //modelBuilder.HasDefaultSchema("dbo");

            //modelBuilder.ApplyConfiguration(new RolesAplicacionesConfiguration());

            // Configure entity relationships and constraints here if needed
        }

        public DbSet<Customer> Customers => Set<Customer>();

    }
}
