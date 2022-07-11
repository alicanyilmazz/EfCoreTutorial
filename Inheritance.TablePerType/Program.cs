using Inheritance.TablePerType.DAL;

using (var context = new AppDbContext())
{
    context.BasePersons.Add(new Manager() { FirstName = "Alican", LastName = "Yilmaz", Age = 22, Degree = 2 }); // BasePerson üzerinden de ekleme yapabiliriz.

    context.BasePersons.Add(new Employee() { FirstName = "Jackie", LastName = "CS", Age = 22, Salary = 1244 }); // BasePerson üzerinden de ekleme yapabiliriz.

    context.Managers.Add(new Manager() { FirstName = "Tiff", LastName = "Tech", Age = 22, Degree = 2 }); // Direkt Managers üzerinden de ekleme yapabiliriz.

    context.Employees.Add(new Employee() { FirstName = "Tarik", LastName = "Guney", Age = 34, Salary = 1036 }); // Direkt Employees üzerinden de ekleme yapabiliriz.

    context.SaveChanges();

    var managers = context.Managers.ToList();

    var employees = context.Employees.ToList();

    var persons = context.BasePersons.ToList();

    persons.ForEach(p =>
    {
        switch (p)
        {
            case Manager manager:
                Console.WriteLine($"Manager Entity : {manager.Degree}");
                break;
            case Employee employee:
                Console.WriteLine($"Employee Entity : {employee.Salary}");
                break;
            default:
                break;
        }
    });
}