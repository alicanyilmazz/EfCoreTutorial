using EfCoreTutorial.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var context = new AppDbContext())
{

    context.Products.Add(new Product() { Name = "Thinking in Java" , Price = 212 , Barcode = 21 , Stock = 234});
    context.Products.Add(new Product() { Name = "Red of the claims", Price = 212, Barcode = 21, Stock = 234 });
    context.Products.Add(new Product() { Name = "Morgot Robie", Price = 212, Barcode = 21, Stock = 234 });

    Console.WriteLine($"Context Id : {context.ContextId}");

    //var products = await context.Products.AsNoTracking().ToListAsync();
    //products.ForEach(p =>
    //{
    //    p.Stock += 100;
    //});

    context.SaveChanges();
}