using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace EfCoreTutorial.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlConnection"));
        }

        public override int SaveChanges()
        {
            ChangeTracker.Entries().ToList().ForEach(e =>
            {
                if (e.Entity is Product product)
                {
                    if (e.State == EntityState.Added)
                    {
                        product.CreatedDate = DateTime.Now;
                    }
                }
            });
            return base.SaveChanges();
        }
    }
}
