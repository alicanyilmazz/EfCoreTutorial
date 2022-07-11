using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnedEntityTypesWithFluentAPI.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().OwnsOne(x => x.Person, p =>
            {
                p.Property(x => x.FirstName).HasColumnName("FirstName");
                p.Property(x => x.LastName).HasColumnName("LastName");
                p.Property(x => x.Age).HasColumnName("Age");
            });
            modelBuilder.Entity<Employee>().OwnsOne(x=>x.Person, p =>
            {
                p.Property(x => x.FirstName).HasColumnName("FirstName");
                p.Property(x => x.LastName).HasColumnName("LastName");
                p.Property(x => x.Age).HasColumnName("Age");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
