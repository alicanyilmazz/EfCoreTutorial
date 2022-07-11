using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnedEntityTypesWithFluentAPI.DAL
{
    public class Employee
    {
        public int Id { get; set; }
        public Person Person { get; set; }

        [Precision(18, 2)]
        public decimal Salary { get; set; }
    }
}
