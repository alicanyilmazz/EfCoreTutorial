using KeylessEntityTypes.DAL;
using Microsoft.EntityFrameworkCore;

using (var context = new AppDbContext())
{
    if(context.Categories.FirstOrDefault() == null)
    {
        var category = new Category() { Name = "Electronics" };
        category.Products.Add(new() { Name = "Ipad", Price = 232, Stock = 2, Barcode = 32, ProductFeature = new ProductFeature() { Color = "Gray", Height = 21, Width = 34 } });
        category.Products.Add(new() { Name = "Phone", Price = 3, Stock = 12, Barcode = 45, ProductFeature = new ProductFeature() { Color = "Black", Height = 11, Width = 14 } });
        category.Products.Add(new() { Name = "Kindle", Price = 132, Stock = 222, Barcode = 452, ProductFeature = new ProductFeature() { Color = "Gray", Height = 11, Width = 11 } });

        context.Categories.Add(category);
        context.SaveChanges();
    }

    var productDetails1 = context.ProductDetail1.FromSqlRaw(@"select p.Id, c.Name 'CategoryName',p.Name,p.Price,pf.Height from Products p 
        join ProductFeature pf on p.Id = pf.Id
        join Categories c on p.CategoryId = c.Id").ToList();

    var productDetails2 = context.ProductDetail2.FromSqlRaw(@"select c.Name 'CategoryName',p.Name,p.Price,pf.Height from Products p 
        join ProductFeature pf on p.Id = pf.Id
        join Categories c on p.CategoryId = c.Id").ToList();

    var productDetails3 = context.ProductDetail3.FromSqlRaw(@"select p.Id 'Product_Id', c.Name 'CategoryName',p.Name,p.Price,pf.Height from Products p 
        join ProductFeature pf on p.Id = pf.Id
        join Categories c on p.CategoryId = c.Id").ToList();
}