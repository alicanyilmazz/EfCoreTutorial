using OnetoManyDataInsert.DAL;

Initializer.Build();

using(var context = new AppDbContext())
{
    var category = new Category() { Name = "Smart Pencil" };

    var product = new Product() { Name = "Apple Pencil" , Price = 10 , Stock = 21 , Barcode = 12 , Category = category }; // Burda Category props ına direkt 3 , 5 gibi bir Category verebilirdik ama vermedik çünkü bu product ı eklemek istediğimiz category DB de yok onu da şimdi ekliyoruz o yuzden bu category e ait bir ıd bilgiside yok, o yuzden direkt EFCore product ı eklerken category sini de ekleyip bu  product a verebilsin diye Product nesnesinin category bilgisini bu şekilde verdik.

    //context.Categories.Add(category);  --> Buna gerek yok cunku Category bilgisini yukarıda Navigation Property üzerinden verdik Product nesnesine EFCore Category i de otomatik olarak Database e ekler.
    //context.Add(product); --> context üzerinden de ekleme yapabilirsiniz ama en temiz olanı DB set üzerinden eklemektir ki orda ekstra methodlarda geliyor kullanabilirsiniz.
    context.Products.Add(product);

    context.SaveChanges();
}

using (var context = new AppDbContext())
{
    var category = new Category() { Name = "EBook" };

    category.Products.Add(new Product() { Name = "Amazon Kindle", Price = 10, Stock = 21, Barcode = 12 }); // dikkat edersek product ın Category propsını vermedik
    category.Products.Add(new() { Name = "Kobo", Price = 10, Stock = 21, Barcode = 12 }); // çünkü zaten category.Products.Add derken category üzerinden ekleme yapıyoruz yani category bilgisi zaten belli. İstersek verebiliriz ama  Kod kirliliğine gerek yok.

    context.Add(category);

    context.SaveChanges();
}

using (var context = new AppDbContext())
{
    var category = new Category() { Name = "Phsical Book" };

    category.Products.AddRange(new List<Product>()
    {
        new() { Name = "Game Of Thrones", Price = 10, Stock = 21, Barcode = 12 },
        new() { Name = "Harry Potter", Price = 10, Stock = 21, Barcode = 12 }
    });

    context.Add(category);

    context.SaveChanges();
}

using (var context = new AppDbContext())
{
    var category = context.Categories.First(x=>x.Name == "EBook");

    var product = new Product() { Name = "Japan Kobo", Price = 10, Stock = 21, Barcode = 12, Category = category }; // istersen navigation property üzerinden eğer elinde Category nesnesi var ise ürünün category bilgisini verebilirsin , 
    var product2 = new Product() { Name = "Tesla ERead", Price = 10, Stock = 21, Barcode = 12, CategoryId = category.Id }; // yok ben category id yi biliyorum onun üzerinden ürün kategorisini vereceğim dersende bu şekilde de Id üzerinden de verebilirsin.

    context.Add(category);

    context.SaveChanges();
}