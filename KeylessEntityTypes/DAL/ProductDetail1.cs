using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeylessEntityTypes.DAL
{
    public class ProductDetail1
    {
        // Naming Convension Gereği EFCore bunun PrimaryKey oldugunu anlar onlar Keyless kullanmamıza gerek yoktur. Tabi SQL sorgusuda program.cs deki gibi olmalıdır.
        public int Id { get; set; } 
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Height { get; set; }
    }
}
