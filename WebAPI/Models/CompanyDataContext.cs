using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class CompanyDataContext : DbContext
    {
        public CompanyDataContext(DbContextOptions<CompanyDataContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
                .HasIndex(e => new { e.EmployeeId, e.Name })
                .IsUnique();

            modelBuilder.Entity<Department>()
                .HasIndex(d => new { d.DepartmentId, d.Name })
                .IsUnique();

            modelBuilder.Entity<Position>()
                .HasIndex(p => new { p.PositionId, p.Name })
                .IsUnique();
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
