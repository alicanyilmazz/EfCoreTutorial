using OnetoOneDataInsert.DAL;

Initializer.Build();

using(var context = new AppDbContext())
{
    //Product => Parent Entity
    //ProductFeature => Child Entity

    var product = new Product() { Name = "Rise of the Ottoman", Price = 23, Stock = 21, Barcode=3};
    context.Products.Add(product); 
    context.SaveChanges();

    // Burada dogrudan bir Product tablosuna Insert yapabiliriz çünkü Product tablosu Parent Entity,
    // Fakat dogrudan ProductFeature tablosuna veri eklemek isteseydik ekleyemezdik.
    // Çünkü ProductFeature veri eklemeden önce Productlara bir kayıt girilmeli veya daha once ProductFeature tablosuna kayıt ettirilmemiş ProductFeature'ı olmayan bir Product
    // tablosunundaki kaydın id si ile 
    //ProductFeature tablosuna kayıt eklenmelidir.
    // Kısaca yukarıda Product tablosunda bir kayıt olupta ProductFeature tablosunda olmayabilir. Ama tam tersi olamaz , ProductFeature da kayıt olup da Product tablosunda kaydı olmayan bir nesne olamaz.
}

// Aşağıda Parent Üzerinden Child ı da ekleyerek kayıt ekledik tablomuza.
using (var context = new AppDbContext())
{
    //Product => Parent Entity
    //ProductFeature => Child Entity

    var product = new Product() { Name = "Rise of the Ottoman", Price = 23, Stock = 21, Barcode = 3 , ProductFeature = new ProductFeature() { Color = "red" , Height = 1, Width = 3}}; // ProductFeature un Product props ını doldurmadık cunku zaten Product ı üzerinden ekleme yapıyoruz.
    context.Products.Add(product);
    context.SaveChanges();

}

// Aşağıda Child Üzerinden Parent ı da ekleyerek kayıt ekledik tablomuza.
using (var context = new AppDbContext())
{
    //Product => Parent Entity
    //ProductFeature => Child Entity

    var product = new Product() { Name = "Rise of the Ottoman", Price = 23, Stock = 21, Barcode = 3};
    var productFeature = new ProductFeature() { Color = "red", Height = 1, Width = 3, Product = product };
    context.ProductFeatures.Add(productFeature);
    context.SaveChanges();

}