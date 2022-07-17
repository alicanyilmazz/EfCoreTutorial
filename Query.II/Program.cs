﻿using Query.II.InnerJoin.DAL;

using (var context = new AppDbContext())
{
    if (context.Categories.FirstOrDefault() == null)
    {
        var category = new Category() { Name = "Electronics" };
        category.Products.Add(new() { Name = "Macbook Pro 13 inch", Price = 123, Stock = 23, Barcode = 923, ProductFeature = new() { Color = "red", Height = 2, Width = 3 } });
        category.Products.Add(new() { Name = "Macbook Air 13 inch", Price = 213, Stock = 22, Barcode = 965, ProductFeature = new ProductFeature() { Color = "blue", Height = 1, Width = 9 } });
        category.Products.Add(new() { Name = "Macbook Pro 14 inch", Price = 34, Stock = 2, Barcode = 33, ProductFeature = new ProductFeature() { Color = "gray", Height = 1, Width = 9 } });
        category.Products.Add(new() { Name = "Macbook Pro Max 16 inch", Price = 13, Stock = 4, Barcode = 47, ProductFeature = new ProductFeature() { Color = "pink", Height = 1, Width = 9 } });
        category.Products.Add(new() { Name = "Iphone 13 Pro", Price = 44, Stock = 31, Barcode = 11, ProductFeature = new ProductFeature() { Color = "orange", Height = 1, Width = 9 } });
        category.Products.Add(new() { Name = "Iphone 13 Max", Price = 66, Stock = 3, Barcode = 31, ProductFeature = new ProductFeature() { Color = "rose", Height = 1, Width = 9 } });
        category.Products.Add(new() { Name = "Apple Watch", Price = 83, Stock = 44, Barcode = 55, ProductFeature = new ProductFeature() { Color = "black", Height = 1, Width = 9 } });
        category.Products.Add(new() { Name = "Apple Watch SE", Price = 96, Stock = 56, Barcode = 99, ProductFeature = new ProductFeature() { Color = "seablue", Height = 1, Width = 9 } });
        category.Products.Add(new() { Name = "Iphone SE", Price = 553, Stock = 676, Barcode = 7, ProductFeature = new ProductFeature() { Color = "darkgray", Height = 1, Width = 9 } });

        await context.Categories.AddAsync(category);

        await context.SaveChangesAsync();
    }
    //--------------------------------------------------------------------------------------------------------------------//
    var joinTypeOne = context.Categories.Join(context.Products, x => x.Id, y => y.CategoryId, (c, p) => new
    {
        CategoryName = c.Name,
        ProductName = p.Name,
        ProductPrice = p.Price,
    }).ToList();

    joinTypeOne.ForEach(x =>
    {
        Console.WriteLine($"{x.CategoryName} {x.ProductName} {x.ProductPrice}");
    });
    //--------------------------------------------------------------------------------------------------------------------//

    var joinTypeTwo = (from c in context.Categories
                      join p in context.Products on c.Id equals p.CategoryId
                      select p).ToList();

    //--------------------------------------------------------------------------------------------------------------------//

    var joinTypeThree = (from c in context.Categories
                       join p in context.Products on c.Id equals p.CategoryId
                       select new
                       {
                           CategoryName = c.Name,
                           ProductName = p.Name,
                           ProductPrice = p.Price
                       }).ToList();

    //--------------------------------------------------------------------------------------------------------------------//

    var products = context.Categories.Join(context.Products, x => x.Id, y => y.CategoryId, (c, p) => p).ToList();

    //--------------------------------------------------------------------------------------------------------------------//

    var categories = context.Categories.Join(context.Products, x => x.Id, y => y.CategoryId, (c, p) => c).ToList();

    //--------------------------------------------------------------------------------------------------------------------//

    // 3 lü join
    var TripleJoinTypeOne = context.Categories
        .Join(context.Products, c => c.Id, p => p.CategoryId, (c, p) => new { c, p })
        .Join(context.ProductFeature, x => x.p.Id, y => y.Id, (c, pf) => new
        {
            CategoryName = c.c.Name,
            ProductName = c.p.Name,
            ProductColor = pf.Color
        });

    //--------------------------------------------------------------------------------------------------------------------//

    var TripleJoinTypeTwoForC = (from c in context.Categories
                             join p in context.Products on c.Id equals p.CategoryId
                             join pf in context.ProductFeature on p.Id equals pf.Id
                             select c).ToList();

    //--------------------------------------------------------------------------------------------------------------------//

    var TripleJoinTypeTwoForP = (from c in context.Categories
                             join p in context.Products on c.Id equals p.CategoryId
                             join pf in context.ProductFeature on p.Id equals pf.Id
                             select p).ToList();

    //--------------------------------------------------------------------------------------------------------------------//

    var TripleJoinTypeTwoForAnonymous = (from c in context.Categories
                                 join p in context.Products on c.Id equals p.CategoryId
                                 join pf in context.ProductFeature on p.Id equals pf.Id
                                 select new
                                 {
                                     CategoryName = c.Name,
                                     ProductName = p.Name,
                                     ProductColor = pf.Color
                                 }).ToList();

    //--------------------------------------------------------------------------------------------------------------------//

    var TripleJoinTypeTwoForAllOf = (from c in context.Categories
                                 join p in context.Products on c.Id equals p.CategoryId
                                 join pf in context.ProductFeature on p.Id equals pf.Id
                                 select new {c,p,pf}).ToList();

    TripleJoinTypeTwoForAllOf.ForEach(x =>
    {
        Console.WriteLine($"{x.c.Name} {x.p.Name} {x.pf.Color}");
    });

    //--------------------------------------------------------------------------------------------------------------------//
}