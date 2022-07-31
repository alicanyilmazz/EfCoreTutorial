using Microsoft.EntityFrameworkCore;
using QueryTags.DAL;

using (var context = new AppDbContext())
{
    var productsWithFeatures = context.Products.TagWith(SQLQUERYMESSAGES.GettingProductsWithProductFeatures).Include(x => x.ProductFeature).Where(x=>x.Price > 30).ToList();

    Console.WriteLine("");
}

class SQLQUERYMESSAGES
{
    public static string GettingProductsWithProductFeatures = "This Query Gets Products with ProductFeature.";
}