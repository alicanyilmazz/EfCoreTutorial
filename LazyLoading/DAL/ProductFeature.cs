using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoading.DAL
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        public virtual Product Product { get; set; }
    }
}
