using Microsoft.EntityFrameworkCore;
using Multi_Tenant_SaaS_API.Models;

namespace Multi_Tenant_SaaS_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add multi-tenant query filter
            modelBuilder.Entity<Project>().HasQueryFilter(p => EF.Property<int>(p, "TenantId") == CurrentTenantId);
        }

        public int CurrentTenantId { get; set; }
    }
}
