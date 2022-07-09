using EagerLoading.DAL;
using Microsoft.EntityFrameworkCore;

using (var context = new AppDbContext())
{
    if(context.Categories.FirstOrDefault() == null)
    {
        var category = new Category() { Name = "Electronics" };
        category.Products.Add(new() { Name = "Macbook Pro 13 inch", Price = 123, Stock = 12, Barcode = 21, ProductFeature = new() { Color = "red", Height = 2, Width = 3 } });
        category.Products.Add(new() { Name = "Macbook Air 13 inch", Price = 13, Stock = 22, Barcode = 31, ProductFeature = new ProductFeature() { Color = "blue", Height = 1, Width = 9 } });

        await context.Categories.AddAsync(category);

        await context.SaveChangesAsync();
    }

    var categoriesWithProducts = context.Categories.Include(x=>x.Products).FirstOrDefault(); // Category ' yi ve bu Category ye baglı olan Product ' ları getirir. // Condition yazmadıgımız için FirstOrDefault içine ilk kaydı getirir.

    if (categoriesWithProducts is not null && categoriesWithProducts.Name is not null)
    {
        Console.WriteLine(categoriesWithProducts.Name);

        foreach (var item in categoriesWithProducts.Products)
        {
            Console.WriteLine(item.Name + item.Barcode + item.Price + item.Stock);
        }
    }

    // Category ' leri ve bu Category lere baglı olan Product ' ları ve bu Product lara da baglı olan ProductFeature ları getirir.
    var categoriesWithProductsWithProductFeatures = context.Categories.Include(x => x.Products).ThenInclude(x=>x.ProductFeature).First();
    // Eğer ProductFeature a baglı getirmek istediğiniz baska birsey daha olsaydı .ThenInclude(x=>x.ProductFeatureBaglıBirsey).First(); şeklinde devam edebilirsiniz.

    Console.WriteLine(categoriesWithProductsWithProductFeatures.Name);

    if (categoriesWithProductsWithProductFeatures is not null && categoriesWithProductsWithProductFeatures.Products is not null)
    {
        foreach (var product in categoriesWithProductsWithProductFeatures.Products)
        {
            Console.WriteLine(product.Name + product.Price + product.Barcode + product.ProductFeature.Color + product.ProductFeature.Height + product.ProductFeature.Width);
        }
    }

    // Peki biz ProductFeature dan Product sonrasında Category e gidecek sekilde nasıl yapabiliriz aşagıda görüyorsunuz.
    var productFeature = context.ProductFeature.Include(x => x.Product).ThenInclude(x=>x.Category).First();

    // Peki biz Product üzerinden ProductFeature ve Category e gidecek sekilde nasıl yapabiliriz aşagıda görüyorsunuz.
    var products = context.Products.Include(x=>x.ProductFeature).Include(x=>x.Category).First();
    /*
     ÖNEMLİ NOT :
     
    -> Yukarıda Category -> Product -> ProductFeature ' ları cekerken " Include ve ThenInclude " kullandık. (1)
    
    -> Yukarıda ProductFeature -> Product -> Category ' ları cekerken " Include ve ThenInclude " kullandık. (2)

    -> Fakat Yukarıda Product -> ProductFeature -> Category ' ları cekerken " Include ve Include " kullandık. Bunun sebebi nedir? (3)

    Çünkü ilk ikisinde , Baslangıc Entity lerinin içinde diğer iki Entity türünden sadece birine ait Navigation Property bulunmakta iken , 
    
    Product -> ProductFeature -> Category da ise Product içerisinde hem ProductFeature ' a hemde Category türünden Navigation Property miz oldugundan ThenInclude yerine Include kullandık.
    Ha eğer bu sorgu devam ettirilip Örn X Entity si daha bu sorguya eklenmek istenseydi ve Product class ının içinde bu Entity türünden bir Navigation Property olmasaydı o zaman " ThenInclude " kullanacaktık.
     
     */

    /*
     KISACA EFCORE EAGER LOADING DE GETIRMEK ISTEDIGINIZ ILISKILI ENTITY LERI ARKA PLANDA SQL JOIN LERI ILE GETIRIYOR.
     
     */
}