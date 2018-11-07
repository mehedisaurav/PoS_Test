﻿using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Supplier : Entity
    {
        public Guid SupplierId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Company { get; set; }

        public string Note { get; set; }

        public double Due { get; set; }

        public double Paid { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }


    }
}
