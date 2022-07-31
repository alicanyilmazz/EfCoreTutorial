using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalQueryFilters.II.DAL
{
    public class AppDbContext : DbContext
    {
        //private readonly ITenantService tenantService;
        private readonly int Tenant;
        public AppDbContext(int tenant)
        {
            Tenant = tenant;    
        }

        public AppDbContext()
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Card> Cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).UseSqlServer(Initializer.Configuration.GetConnectionString("SqlConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id);

            modelBuilder.Entity<Card>().Property(x=>x.Amount).HasDefaultValue(0);
            modelBuilder.Entity<Card>().Property(x => x.AmountLimit).HasDefaultValue(0);

            //Şöyle de bir kosul koyduk eger Tenan int primitive type yani default değeri 0. Eğer default değerine eşitse Tenant yani değer atanmamış veya 0 
            // atanmış ise Card Entity si için atılan sorgularda bu QueryFilter ımız calısmayacaktır.
            if (Tenant != default(int))
            {
                modelBuilder.Entity<Card>().HasQueryFilter(x => x.TenantId == Tenant && x.TenantCode == "USA");
                //modelBuilder.Entity<Card>().HasQueryFilter(x => x.TenantId == tenantService.TenantId && x.TenantCode == "USA");
            }
            else
            {
                modelBuilder.Entity<Card>().HasQueryFilter(x=> x.TenantCode == "USA");
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
