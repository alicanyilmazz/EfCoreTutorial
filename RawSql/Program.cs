using Microsoft.EntityFrameworkCore;
using RawSql.DAL;

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

    var products = await context.Products.FromSqlRaw("select * from Products").ToListAsync();

    // var products = await context.Products.FromSqlRaw("select Id,Name from Products").ToListAsync(); --> Bu sorgu calismaz * ile hepsini Map lemek zorundayız bunu nasıl
    // yapabileceğimizi sonraki derslerde anlatacağız.

    int id = 5;
    var productsWithParameters = await context.Products.FromSqlRaw("select * from Products where id={0}",id).FirstAsync();

    decimal price = 300;

    // With FromSqlRaw
    var productsWithParameters2 = await context.Products.FromSqlRaw("select * from Products where price>{0}", price).ToListAsync();

    // With FromSqlInterpolated
    var productsWithParameters3 = await context.Products.FromSqlInterpolated($"select * from Products where price>{price}").ToListAsync();

    //--------------------------------------------------------------------------------------------------------------------//

    // context.ProductsEssential kullanıdıgımıza dikkat edelim , "select Id,Name,Price from Products" gibi Id yi çekmiyoruz dikkat ederseniz.
    var productsWithParameters4 = await context.ProductsEssential.FromSqlRaw($"select Name,Price from Products").ToListAsync();

    // NOT : Her zaman "modelBuilder.Entity<ProductsEssential>().HasNoKey();" gibi join yaptıgımız Custom sorgularda HasNoKey kullanmalısın, evet eğer select sorgusunda
    // select Id,.... from Products Id yi de çekersen EFCore hata vermez cunku bunu PrimaryKey-ClusteredIndex sanar ama aslında bu Custom sorgu yazdıgımız için sadece burda
    // bir Select işlemi veri görüntüleme işlemi yaptıgımızdan dolayı o Id alanı PrimaryKey değil sıradan bir Column ' dır aslında o yuzden EFCore u yanıltmaya bile gerek 
    // olmadan Best Practice gereği Custom sorgularınızda her zaman ".HasNoKey()" ile bu sorgusonucu dönen tablonun bir PrimaryKey ı olmadıgını EFCore a bildirin.
    // Mesela 3 5 tablonun istediğimiz Column larını secerek Joinleyerek bir tablo elde ettik diyelim , bu bir gercek tablo değil dolayısıyla ordaki Id alanlarıda artık
    // yeni olusan tabloda birer sıradan Column dır aslında.

    //--------------------------------------------------------------------------------------------------------------------//

    var productsWithFeature = await context.ProductWithFeatures.FromSqlRaw("select p.Id,p.Name,p.Price,pf.Color,pf.Height from Products p inner join ProductFeature pf on p.Id = pf.Id").ToListAsync();

    Console.WriteLine("");
}

/*
 
 var productsWithParameters = await context.Products.FromSqlRaw("select * from Products where id={0}",id).ToListAsync();

 var values = String.Format("products : {0} - {1}", 1, "iphone"); //bu formata benzer bir sekilde yazıyoruz yukarıdaki sql sorgusunu da.
 
 
 */