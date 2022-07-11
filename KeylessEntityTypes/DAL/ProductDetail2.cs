using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeylessEntityTypes.DAL
{
    [Keyless] // Data Annotation Kullanarak da bu sekilde Keyless yapabilirsiniz.
    public class ProductDetail2
    {
        public int Product_Id { get; set; } // EFCore Convension gereği bunu PrimaryKey olarak algılayamaz otomatik olarak o yuzden Keyless özelliğini ekliyoruz.
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Height { get; set; }
    }
}
