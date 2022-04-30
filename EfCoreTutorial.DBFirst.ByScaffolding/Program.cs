using EfCoreTutorial.DBFirst.ByScaffolding.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new EFCoreDatabaseFirstDbContext())
{
    var products = await context.Products.ToListAsync();
    products.ForEach(p =>
    {
        // p.Stock.HasValue ile kontrol yapılması lazım Stock nullable unutma!
        Console.WriteLine(p.Name + " " + p.Price + " " + p.Stock);
    });
}