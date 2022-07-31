using Microsoft.EntityFrameworkCore;
using TrackingAndNoTracking.DAL;

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

        await context.Categories.AddAsync(category);

        await context.SaveChangesAsync();
    }
    #endregion

    //--------------------------------------------------------------------------------------------------------------------//

    // EFCore Tracking to Data Begin
    var productWithTracking = context.Products.FirstOrDefault(x=> x.Id == 2);

    productWithTracking.Name = "Mac mini";

    context.SaveChanges();
    // EFCore Tracking to Data End

    // EFCore No Tracking to Data Begin
    var productNoTracking = context.Products.AsNoTracking().FirstOrDefault(x => x.Id == 2);

    productWithTracking.Name = "Mac mini";

    // Cekilen datamız Track edilmediği için Update işleminin DB ye yansıtılabilmesi için 
    context.Entry(productNoTracking).State = EntityState.Modified; // ya State ini Modified olarak Flag lemeliyiz.
    context.Update(productNoTracking); // Yada Update methodunu kullanmalıyız.

    context.SaveChanges();
    // EFCore No Tracking to Data End

    // EFCore No Tracking to Data Begin
    // 3. Secenek olarakda aslında AppDbContext içerisinde .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); methodu ile artık Global düzeyde tüm sorgularımızın Track edilmemesini sağladık.
    // EFCore No Tracking to Data End

}