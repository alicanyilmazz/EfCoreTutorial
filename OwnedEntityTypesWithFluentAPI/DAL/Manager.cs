﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnedEntityTypesWithFluentAPI.DAL
{
    public class Manager
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public int Degree { get; set; }
    }
}
