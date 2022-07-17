using Query.I.DAL;

using (var context = new AppDbContext())
{
    if (context.People.FirstOrDefault() is null)
    {
        context.People.Add(new Person() { Name = "Jackie", Phone = "0123456" });
        context.People.Add(new Person() { Name = "Tiff", Phone = "0965833" });
        context.People.Add(new Person() { Name = "Morgot", Phone = "0596321" });
        context.People.Add(new Person() { Name = "Steve", Phone = "0896532" });
        context.People.Add(new Person() { Name = "Laura", Phone = "0654931" });

        context.SaveChanges();
    }

    //var persons = context.People.Where(x => FormatPhone(x.Phone) == "54652321665").ToList(); // Hata verir

    var persons = context.People.ToList().Where(x => FormatPhone(x.Phone) == "54652321665").ToList();

    var personFormattedData = context.People.ToList().Select(x=> new { PersonName = x.Name, PersonPhone = FormatPhone(x.Phone) }).ToList();

    foreach (var person in personFormattedData)
    {
        Console.WriteLine(person.PersonName + person.PersonPhone);
    }
    
}

string FormatPhone(string phone)
{
    return phone.Substring(1, phone.Length - 1);
}