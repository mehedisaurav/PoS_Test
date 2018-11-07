using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Model;

namespace Test.Model
{
    public class Product : Entity
    {
        public Guid ProductId { get; set; }

        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string UnitMeasurement { get; set; }

        public Guid? SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }

        public Category Category { get; set; }
    }
}
