﻿using EfCoreTutorial.DBFirst.DAL;
using Microsoft.EntityFrameworkCore;

DbContextInitializer.Build(); 

using (var context = new AppDbContext(DbContextInitializer.optionsBuilder.Options))
{
    var products = await context.Products.ToListAsync();
    products.ForEach(p =>
    {
        // p.Stock.HasValue ile kontrol yapılması lazım Stock nullable unutma!
        Console.WriteLine(p.Name + " " + p.Price + " " + p.Stock);
    });
}