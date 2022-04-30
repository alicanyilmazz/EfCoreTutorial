using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTutorial.DBFirst.DAL
{
    public class DbContextInitializer
    {
        public static IConfigurationRoot Configuration;

        public static DbContextOptionsBuilder<AppDbContext> optionsBuilder;

        public static void Build()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
            optionsBuilder = new DbContextOptionsBuilder<AppDbContext>(); // 2. yontemi kullanacaksak buna 
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlCon")); // ve buna ihtiyac yok
        }
    }
}
