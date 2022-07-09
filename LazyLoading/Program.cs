using LazyLoading.DAL;
using Microsoft.EntityFrameworkCore;

using (var context = new AppDbContext())
{
    if (context.Categories.FirstOrDefault() == null)
    {
        var category = new Category() { Name = "Electronics" };
        category.Products.Add(new() { Name = "Macbook Pro 13 inch", Price = 123, Stock = 12, Barcode = 21, ProductFeature = new() { Color = "red", Height = 2, Width = 3 } });
        category.Products.Add(new() { Name = "Macbook Air 13 inch", Price = 13, Stock = 22, Barcode = 31, ProductFeature = new ProductFeature() { Color = "blue", Height = 1, Width = 9 } });

        await context.Categories.AddAsync(category);

        await context.SaveChangesAsync();
    }

    var _category = await context.Categories.FirstAsync();

    var products = _category.Products; // Lazy Loading i aktif ettiğimizden dolayı biz _category nin Product Navigation Property sine erişmeye çalıştıgımız anda EFCore
    // arka planda SQL Sorgusu atıp Product verilerini otomatik getirir.

    foreach (var product in products)
    {
        // N+1 Problem
        Console.WriteLine(product.Name + product.Price);
    }
   
}
 