using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeylessEntityTypes.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductDetail1> ProductDetail1 { get; set; }
        public DbSet<ProductDetail2> ProductDetail2 { get; set; }
        public DbSet<ProductDetail3> ProductDetail3 { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id);

            modelBuilder.Entity<ProductDetail3>().HasNoKey(); // Fluent API Kullanarakda bu sekilde Keyless yapabilirizsiniz.

            base.OnModelCreating(modelBuilder);
        }
    }
}
