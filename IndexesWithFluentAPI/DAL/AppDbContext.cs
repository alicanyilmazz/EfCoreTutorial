using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexesWithFluentAPI.DAL
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

            modelBuilder.Entity<Product>().HasIndex(x=>x.Name); // FluentAPI kullanarak DB de olusacak olan 'Name' Column ına index vermiş olduk.
            modelBuilder.Entity<Product>().HasIndex(x=> new {x.Barcode, x.Stock}); // FluentAPI kullanarak DB de Composite index olusturmus olduk.

            // Quantity Column ına index ekledik , Price ve Tax Column 'ınlarını da Include Column olarak ekledik.
            modelBuilder.Entity<Product>().HasIndex(x => x.Quantity).IncludeProperties(x=> new {x.Price,x.Tax}); 

            base.OnModelCreating(modelBuilder);
        }
    }
}

/*
 
PrimarKey yokken -> Table Scan
PrimaryKey ekledikten sonra -> Clustered Index Scan
Index ekledikten sonra (Included Column Data Yoksa) -> Index Seek ve Key Lookup
Index ekledikten sonra (Included Column Data Varsa) -> Index Seek

context.Products.where(x=>x.name = "Macbook").select(x=>x.Name);  <-----> Dediğimizde ve sadece Name Column ına index koydugumuzda Select ı da sadece Name e atıyoruz o zaman
Index den dolayı sorgu performansımız normalden cok cok iyi bir sekilde olacaktır.

Fakat ,
context.Products.where(x=>x.name = "Macbook").First(); veya
context.Products.where(x=>x.Name = "Macbook").select(x=>new {name = x.Name , price = x.Price});

Dediğimizde ise Name alanında index var normalden hızlı calısacak ama artık Select de diğer alanlarıda 
getirmek istiyoruz bu sorguyu daha da performanslı yapabiliriz, Bunu da Name e ait olan Index Page lerimize Included Columns lar ekleyerek yapabiliriz.

 */