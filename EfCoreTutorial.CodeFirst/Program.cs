using EfCoreTutorial.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var context = new AppDbContext())
{
    var products = await context.Products.ToListAsync();
    products.ForEach(p =>
    {
        // p.Stock.HasValue ile kontrol yapılması lazım Stock nullable unutma!
        Console.WriteLine(p.Name + " " + p.Price + " " + p.Stock);
    });
}