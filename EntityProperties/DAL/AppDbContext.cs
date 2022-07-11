using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProperties.DAL
{
    public class AppDbContext : DbContext
    {
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

            // Bu sekilde Product Entity si içerisinde bulunan Stock alanının DB de olusmasını Fluent API kullanarak engellemiş olduk.
            modelBuilder.Entity<Product>().Ignore(x=>x.Stock);

            // Bu sekilde Product Entity si içerisinde bulunan Content artık nvarchar yerine varchar olacak Database de.
            modelBuilder.Entity<Product>().Property(x => x.Content).IsUnicode(false); 

            // Bu sekilde Product Entity si içerisinde bulunan ProducerCountry alanının tipini ve Database deki Column ismini FluentAPI kullanarak vermiş olduk.
            modelBuilder.Entity<Product>().Property(x => x.ProducerCountry).HasColumnType("nvarchar(200)").HasColumnName("ProducerCountry");  

            base.OnModelCreating(modelBuilder);
        }
    }
}
