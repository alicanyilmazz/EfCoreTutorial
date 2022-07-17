using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RawSql.SqlMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawSql.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductsEssential> ProductsEssential { get; set; } // ÖNEMLİ : Bu 
        public DbSet<ProductWithFeature> ProductWithFeatures { get; set; } // Ve bu iki DB den gelen verileri Map lemek için kullandıgımız class ları biz DbSet e ekledik ki 
        // Bu iki class a context üzerinden erişebilelim ve DB den cekilen verileri bunlara Mapleyebilelim. Fakat bunlar DB de olmaması gereken Class lar sadece kod tarafında
        // Gelen verileri Map lemek için kullanıyoruz ama DbSet e eklediğimizden dolayı Migration yaptıgımızda EFCore bunları DB ye yansıtacaktır ama bunlar Entity değil
        // yani DB de herhangi bir tabloya karsılık gelmiyor 2 3 tabloyu joinleyip içindeki verileri bunlara atıyoruz , Peki bunların Migration esnasında olusmasını engelleyecek
        // herhangi bir EFCore komutu var mı ? Malesef yok . Bunu ancak Migration yaptıktan sonra Migration dosyasının içerisinde bu iki Class ı DB de Olusturmak için 
        // ilgili configuration lar olusturulacaktır Up ve Down methodlarında işte biz onları silip , sonrasında update-database yaparak bu alanların DB de tablo olarak
        // olusmasını engellemiş oluruz. Bunun için EFCore da hazır bir method bulunmamaktadır.
        // Peki OnModelCreating içerisinde modelBuilder.Ignore<ProductWithFeature>(); diyemez miydik ? Eğer Ignore methdunu kullanırsanız , O zaman Program.cs içerisinde
        // await context.ProductWithFeatures.FromSqlRaw("select p.Id,p.Name,p.Price,pf.Color,pf.Height from Products p inner join ProductFeature pf on p.Id = pf.Id").ToListAsync();
        // gibi ProductsEssential ve ProductWithFeatures lara context üzerinden erişmezsiniz. 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).UseSqlServer(Initializer.Configuration.GetConnectionString("SqlConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id);

            modelBuilder.Entity<ProductsEssential>().HasNoKey(); // ProductsEssential mizin PrimaryKey i olmadıgını EFCore a söylüyoruz.
            // Çünkü context.ProductsEssential.FromSqlInterpolated($"select Id,Name,Price from Products where price>{price}").ToListAsync();
            // İfadesinde Id alanını kullanmayabiliriz veya olmayabilir Cektiğimiz tablolarda Id alanını yazmazsak hata verir ama bunu EFCore a burda bildirirsek EFCore
            // hata vermez. context.ProductsEssential.FromSqlInterpolated($"select Name,Price from Products where price>{price}").ToListAsync();
            // Sorgumuzu rahatlıkla çalıştırabiliriz. Sonucta ProductsEssential class ı bir Entity değil DB de karsılık geldiği herhangi bir tablo yok sadece
            // Sorgu sonucunda çekmiş oldugumuz data yı kod tarafında Map lemek için kullanıyoruz bu sınıfı , ve erişebilmek içinde DBSet lere ekledir o kadar.          

            /*
                 modelBuilder.Entity<ProductsEssential>().Ignore(x => x.Price); // dediğimizde ise artık bu DB de olusuturmayacaktır anlamında ama bu DB tablosu olmadıgı için
                // zaten context üzerinden Price a da erişemezsin anlamında olacaktır.
                public class ProductsEssential
                {
                    public int Id { get; set; }
                    public string Name { get; set; }
                    [NotMapped]  // ile  modelBuilder.Entity<ProductsEssential>().Ignore(x => x.Price); aynıdır.
                    public decimal Price { get; set; }
                }
                
                // Yani ben demiş oluyorum ki sen bunu DB de olusturma ben bu Price alanını kodda ben vericem , DB den gelmesine olmasına gerek yok , tabi Price için 
                // Mantıklı değilde bu gibi durumların istenildiği parametre props ları vb gibi kodda verilmesi gereken DB olmasına gerek olmayan Props lar olabilir.
             */

            modelBuilder.Entity<ProductWithFeature>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}
