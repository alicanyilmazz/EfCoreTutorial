using GlobalQueryFilters.DAL;
using Microsoft.EntityFrameworkCore;

using (var context = new AppDbContext())
{
    #region AddDataIfNotExist
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
        category.Products.Add(new() { Name = "Imac", Price = 34, Stock = 1, Barcode = 34, ProductFeature = new() { Color = "Rose", Height = 12, Width = 33 } });
        category.Products.Add(new() { Name = "Motorola X63", Price = 4, Stock = 13, Barcode = 341, ProductFeature = new ProductFeature() { Color = "orange", Height = 21, Width = 9 } });
        category.Products.Add(new() { Name = "Acer XSpace", Price = 324, Stock = 32, Barcode = 433, ProductFeature = new ProductFeature() { Color = "gray", Height = 1, Width = 9 } });
        category.Products.Add(new() { Name = "Acer Nitro Monitor", Price = 123, Stock = 34, Barcode = 447, ProductFeature = new ProductFeature() { Color = "pink", Height = 1, Width = 9 } });
        category.Products.Add(new() { Name = "Nexus M2", Price = 454, Stock = 311, Barcode = 141, ProductFeature = new ProductFeature() { Color = "orange", Height = 1, Width = 9 } });
        category.Products.Add(new() { Name = "Dell Inspare", Price = 616, Stock = 33, Barcode = 431, ProductFeature = new ProductFeature() { Color = "rose", Height = 1, Width = 9 } });
        category.Products.Add(new() { Name = "Dell Alienware", Price = 833, Stock = 414, Barcode = 545, ProductFeature = new ProductFeature() { Color = "black", Height = 1, Width = 9 } });
        category.Products.Add(new() { Name = "Casper Via", Price = 446, Stock = 1356, Barcode = 919, ProductFeature = new ProductFeature() { Color = "seablue", Height = 1, Width = 9 } });
        category.Products.Add(new() { Name = "Casper Olympos", Price = 5153, Stock = 4676, Barcode = 887, ProductFeature = new ProductFeature() { Color = "darkgray", Height = 1, Width = 9 } });

        context.Categories.Add(category);

        context.SaveChanges();
    }
    #endregion

    //Product için Global olarak QueryFilter tanıladıgımızdan dolayı olusan SQL de bize "IsDeleted" alanı True olan kayıtlar getirilmeyecektir.
    // EFCore DB ye atacagı SQL i olustururken sorguya gidip sorguya AppDbContext in içerisindeki OnModelCreating içinde tanımlı olan QueryFilter i da ekleyecektir.
    var products = context.Products.ToList();

    // Peki ya bazen bu QueryFilter olmadan sorgu atma ihtiyacım dogarsa?
    // İşte o zaman "IgnoreQueryFilters()" methodunu kullanarak EFCore a bu sorgu için olusturacagı SQL e ilgili filtrenin eklenmemesi gerektiğini söylemiş olduk.
    var productsWithNoFilter = context.Products.IgnoreQueryFilters().ToList();

    Console.WriteLine("");
}