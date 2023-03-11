using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using PrimeHolding_Internship.Infrastructure.Data.Configuration;
using PrimeHolding_Internship.Infrastructure.Data.Entities;
using Task = PrimeHolding_Internship.Infrastructure.Data.Entities.Task;

namespace PrimeHolding_Internship.Infrastructure.Data
{
    public class AssignmentDbContext : IdentityDbContext
    {
        public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; } = null!;

        public DbSet<Task> Tasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new TaskConfiguration());

            base.OnModelCreating(builder);
        }
    }
}