// See https://aka.ms/new-console-template for more information
using Inheritance.TablePerHierarchy.II.DAL;

Console.WriteLine("Hello, World!");

using (var context = new AppDbContext())
{
    //context.BasePersons.Add(new Manager() { FirstName = "Alican", LastName = "Yilmaz", Age = 22, Degree = 2 });

    //context.BasePersons.Add(new Employee() { FirstName = "Alican", LastName = "Yilmaz", Age = 22, Salary = 1244 });

    //context.SaveChanges();

    var managers = context.Managers.ToList();  // EFCore  [Discriminator] ' ı Manager olan tüm kayıtları getirir.

    var employees = context.Employees.ToList(); // EFCore  [Discriminator] ' ı Employee olan tüm kayıtları getirir.

    var baseperson = context.BasePersons.ToList();  // EFCore  [Discriminator] ' ı hem Manager olan hemde Employee olan  tüm kayıtları getirir.(kısaca kayıtların tamamını getirir.)

    baseperson.ForEach(p =>
    {
        switch (p)
        {
            case Manager manager:
                Console.WriteLine($"{manager.Degree}");
                break;
            case Employee employee:
                Console.WriteLine($"{employee.Salary}");
                break;
            default:
                break;
        }
    });
}