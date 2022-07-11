using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProperties.DAL
{
    public class Product
    {
        public int Id { get; set; }

        [Unicode(false)]
        public string Name { get; set; } // [Unicode(false)] ile Name alanı artık nvarchar yerine varchar olacak Database de. 
        public string Content { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        [Column(TypeName = "char(200)")] 
        public string Producer { get; set; } // Producer alanının tipini [Column(TypeName = "char(200)")] [Column(TypeName = "varchar(200)")] [Column(TypeName = "nvarchar(200)")] gibi istediğimiz gibi verebiliriz.
        public string ProducerCountry { get; set; }

        [NotMapped]
        public int Barcode { get; set; } // NotMapped ile Product Entity si içerisinde bulunan Barcode alanının DB de olusmasını DataAnnotation kullanarak engellemiş olduk.
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ProductFeature ProductFeature { get; set; }
    }
}
