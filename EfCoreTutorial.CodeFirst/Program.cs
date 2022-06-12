using EfCoreTutorial.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var context = new AppDbContext())
{
    /*
    var product = context.Products.First(x=>x.Id == 4); // Id si 4 olan datayı getirir yoksa Exception fırlatır.
    var product2 = context.Products.FirstOrDefault(x => x.Id == 4); // Id si 4 olan datayı getirir yoksa geriye null döndürür.
    var product3 = context.Products.FirstOrDefault(x => x.Id == 4,new Product() { Id = 2 , Barcode = 2 , Name = "Rsa" , Price = 1 , Stock = 1}); // Id si 4 olan datayı getirir yoksa 2.parametre ile verdiğimiz objeyi(Product nesnesini döndürür.)
    var product4 = await context.Products.SingleAsync(x => x.Id == 4);  // Id si 4 olan datayı getirir
    var product5 = await context.Products.SingleAsync(x => x.Id > 4); // Id si 4 den büyük olan birden fazla data bulursa exception fırlatır.
    var products6 = await context.Products.Where(x => x.Id > 10 && x.Name == "mordor" || x.Price >= 12).ToListAsync();
    var products7 = await context.Products.FirstOrDefaultAsync(x => x.Id > 10 && x.Name == "mordor" || x.Price >= 12);

    var productx1 = context.Products.FirstAsync(x => x.Id == 4);
    var productx2 = context.Products.SingleAsync(x => x.Id == 4);
    var productx3 = context.Products.FindAsync(10,36); // normalde tek parametre veririrz oda PRIMARYKEY olmalı ama tablo yapımızda birden fazla column
                                                       // primarykey ise o zaman bunları virgülle sıra ile veirirz ve ona göre datayı getirir.

    var productx4 = context.Products.FindAsync(10);

    context.SaveChanges();
    */
}