using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.ViewModel.ProductView
{
    public class ProductSaveUpdateModelView
    {
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
        public Guid CategoryId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Measure { get; set; }

    }
}
