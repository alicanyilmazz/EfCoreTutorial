using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.TablePerType.DAL
{
        public class AppDbContext : DbContext
        {
            public DbSet<Manager> Managers { get; set; }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<BasePerson> BasePersons { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                Initializer.Build();
                optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlConnection"));
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<BasePerson>().ToTable("Persons");
                modelBuilder.Entity<Employee>().ToTable("Employees");
                modelBuilder.Entity<Manager>().ToTable("Managers");
                base.OnModelCreating(modelBuilder);
            }
        }
}
