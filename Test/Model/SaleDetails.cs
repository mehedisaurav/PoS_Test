using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Model;

namespace Test.Model
{
    public class SaleDetails : Entity
    {
        public Guid SaleDetailsId { get; set; }

        public Guid SaleId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public string MeasureType { get; set; }

        public double Price { get; set; }

        public Product Product { get; set; }

        public Sale Sale { get; set; }
    }
}
