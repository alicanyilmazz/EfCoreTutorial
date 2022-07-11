using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeylessEntityTypesII.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
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

            modelBuilder.Entity<Person>().HasNoKey(); // Fluent API Kullanarakda Person tablosunun Keyless oldugunu EFCore a bildirdik yoksa Person tablosunda PrimaryKey olmadıgından
                                                      // EFCore bize migration yaptırmaz bu Entity nin PrimaryKey alanı yok diye hata verir , oyuzden bunu bilerek yaptıgımızı bildirdik.

            base.OnModelCreating(modelBuilder);
        }
    }
}
