// See https://aka.ms/new-console-template for more information
using IndexesWithFluentAPI.DAL;

Console.WriteLine("Hello, World!");

using (var context = new AppDbContext())
{
    var result = context.Products.Where(x=>x.Name == "Macbook").Select(x=> new {Name = x.Name, Price = x.Price, Stock = x.Stock});
}