
using ExplicitLoading.DAL;

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

    var _category = context.Categories.First();
    //
    // 
    // Burada birtakım Business işlemleri gerçekleştiriyorum. Business kodlarımız var yani burada.
    //
    //
    // Fakat tam burada yukarıdaki _category e baglı bulunan Product lara ihtiyacımız oldu , şuana kadar yoktu o zaman bunları cekmemiz lazım.

    // Bunu iki yol ile yapabiliriz ,

    // Birinci Yol - Klasik yol
    var products1 = context.Products.Where(p => p.CategoryId == _category.Id).ToList();

    // İkinci Yol - Best Practice Yol - Direk Navigation Property ye yükledik Product bilgisini
    context.Entry(_category).Collection(x => x.Products).Load(); // DİKKAT : Bir Category nin birden Fazla Product ı olabiliceğinden Dolayı ' Collection ' reserved keyword unu kullandık.

    foreach (var product in _category.Products)
    {
        Console.WriteLine(product.Name + " " + product.Price + " " + product.Barcode);
    }
}

using (var context = new AppDbContext())
{
    var product = context.Products.First();
    //
    // 
    // Burada birtakım Business işlemleri gerçekleştiriyorum. Business kodlarımız var yani burada.
    //
    //
    // Fakat tam burada yukarıdaki product a baglı bulunan ProductFeature lara ihtiyacımız oldu , şuana kadar yoktu o zaman bunları cekmemiz lazım.

    // İkinci Yol - Best Practice Yol - Direk Navigation Property ye yükledik Product bilgisini
    context.Entry(product).Reference(x=>x.ProductFeature).Load(); // DİKKAT : Bir Product ile ProductFeature arasında One to One ilişki oldugundan ' Reference ' reserved keyword unu kullandık.

}

/*
 
 ÖNEMLİ NOT :

 Yukarda da gördüğünüz gibi Explicity Loading yaparken , Category --> Product gibi 'One to Many' ilişkilerde 'Collection' reserved keyword unu kullanmamız gerekirken,
 Product --> ProductFeature gibi 'One to One' ilişkilerde 'Reference' reserved keyword unu kullanmamız gerekmektedir.
 
 */