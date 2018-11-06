using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.ViewModel.SaleDetails
{
    public class SaleDetailsViewModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int Unit { get; set; }
        public double Price { get; set; }

    }
}
