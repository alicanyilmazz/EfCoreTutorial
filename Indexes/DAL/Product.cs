using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexes.DAL
{
    [Index(nameof(Name))] // DataAnnotation lar ile şekildeki gibi 'Name' Column ın EFCore üzerinden Index verebiliriz. [Index("Name")] şeklinde de verilebilir ama mantıksız.
    [Index(nameof(Barcode),nameof(Stock))] // İki tane birden Index tanımlarsak bu sekilde tanımlanan index lere de Composite Index adı verilir.
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal tax { get; set; }
        public int Stock { get; set; }
        public int Barcode { get; set; } 
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ProductFeature ProductFeature { get; set; }
    }
}

// [Index(nameof(Barcode),nameof(Stock))] -> context.Products.where(x=>x.Name = "Macbook" && x.price > 100) sorgumuz cok performanslı calısacak.

/*
 
PrimarKey yokken -> Table Scan
PrimaryKey ekledikten sonra -> Clustered Index Scan
Index ekledikten sonra (Included Column Data Yoksa) -> Index Seek ve Key Lookup
Index ekledikten sonra (Included Column Data Varsa) -> Index Seek

context.Products.where(x=>x.name = "Macbook").select(x=>x.Name);  <-----> Dediğimizde ve sadece Name Column ına index koydugumuzda Select ı da sadece Name e atıyoruz o zaman
Index den dolayı sorgu performansımız normalden cok cok iyi bir sekilde olacaktır.

Fakat ,
context.Products.where(x=>x.name = "Macbook").First(); veya
context.Products.where(x=>x.Name = "Macbook").select(x=>new {name = x.Name , price = x.Price});

Dediğimizde ise Name alanında index var normalden hızlı calısacak ama artık Select de diğer alanlarıda 
getirmek istiyoruz bu sorguyu daha da performanslı yapabiliriz, Bunu da Name e ait olan Index Page lerimize Included Columns lar ekleyerek yapabiliriz.

 */

// INCLUDE COLUMNS ÖZELLİĞİNİN DATAANNOTATION TARAFINDA TANIMLAMASI YOKTUR BU ÖZELLİK İÇİN FLUENTAPI TARAFINA BAKINIZ.