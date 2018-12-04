using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.ViewModel.ProductView
{
    public class ProductSaveUpdateModelView
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string MeasureType { get; set; }

    }
}
