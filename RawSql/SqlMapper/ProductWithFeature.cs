using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawSql.SqlMapper
{
    public class ProductWithFeature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public int Height { get; set; } // Mapping için kullandıgımız primitive type larda decimal , int ...etc join de kullandıgımız bu alanların NULL gelme durumu olabilir.
        // O yuzden -- public int? Height { get; set; } -- şeklinde props larımızı belirtmeliyiz ki hata almayalım. string ifadeler Reference type oldugundan NULL alabilir
        // Ama primitive type lar alamaz ve join yaptıgımız tablonun bu propsları olmadıgından NULL gelebilir ve hata alabiliriz o yuzden ? kullanmayı unutmayalım.
        // Biz şuan ? kullanmadık cunku join sonucu her ProductFeature ın Product ı olması zorunlu oldugundan NULL gelmeyeceğini bildiğimiz için Height alanına ? koymadık.
        // Aralarındaki One to One Parent Child ilişkisi buna izin vermiyor ama her Join yaptıgımız tabloda böyle bir kısıtlayıcı unsur olmayabiir.
    }
}
