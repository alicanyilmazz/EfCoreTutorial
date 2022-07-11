using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeylessEntityTypesII.DAL
{
    public  class Person // Fluent API kullanarak bu Entity nin Keyless oldugunu OnModelCreating içerisinde belirttik , yoksa bu tablo DB de PrimaryKey alanı olmadıgından EFCore uyarı
    {                    // Uyarı vercek ve DB de bu tabloyu olusturmayacaktı.
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

// DİKKAT : Keyless Entity Types ların DB de olusturulabilmesi için bu Entity nin Keyless oldugu DataAnnotation veya FluentAPI kullanılarak bildirilmelidir.
// DİKKAT : Ayrıca Keyless Entity ler EFCore tarafından track edilmezler o yuzden bu Tablolara INSERT , UPDATE , DELETE gibi COMMAND işlemleri gercekleştirilemez.
// DİKKAT : Keyless Tablolara sadece Select yani Query sorguları atılabilir.
// DİKKAT : Kısaca Tablonuzun PrimaryKey alanı yoksa EFCore tarafından INSERT , UPDATE , DELETE işlemleri gercekleştirilemez sadece SELECT sorguları atılabilir.