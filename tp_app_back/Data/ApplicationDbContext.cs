using Microsoft.EntityFrameworkCore;
using tp_app_back.Models;

namespace tp_app_back.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Employees)
                .WithMany(e => e.Projects)
                .UsingEntity<Dictionary<string, object>>(
                    "ProjectEmployee",
                    j => j.HasOne<Employee>().WithMany().HasForeignKey("EmployeeId"),
                    j => j.HasOne<Project>().WithMany().HasForeignKey("ProjectId")
                );

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Roles)
                .WithMany(r => r.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeRole", // Nom de la table intermédiaire
                    j => j.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    j => j.HasOne<Employee>().WithMany().HasForeignKey("EmployeeId")
                );
        }
    }
}
