// See https://aka.ms/new-console-template for more information

using ManytoManyDataInsert.DAL;

Initializer.Build();

// Student üzerinden Kayıt ekleme
using (var context = new AppDbContext())
{
    var student = new Student() { Name = "Jackie", Age = 32 };
    student.Teachers.Add(new() { Name = "Roselin" });
    student.Teachers.Add(new() { Name = "Michael" });

    context.Add(student);
    context.SaveChanges();
}

// Teacher üzerinden Kayıt ekleme
using (var context = new AppDbContext())
{
    var teacher = new Teacher()
    {
        Name = "Roberta",
        Students = new() // new List<Student>() aslında bu farklı kullanımlarını da gör diye yazdım.
        {
           new() { Name = "Laura", Age = 21 },
           new Student() { Name = "Jackie", Age = 31 }
        }
    };

    context.Add(teacher);
    context.SaveChanges();
}

// DB den çektiğimiz bir kayıt da Veri eklemek
using (var context = new AppDbContext())
{
    var teacher = context.Teachers.First(x => x.Name == "Roberta");

    teacher.Students.AddRange(new List<Student>()
    {
        new(){Name = "Michael", Age = 21},
        new Student(){Name = "Cristiana", Age = 6}
    });

    context.SaveChanges(); // DİKKAT : context.Add() kullanmadık çünkü teacher ' ı DB den cektik zaten Memory de Track ediliyor.
}