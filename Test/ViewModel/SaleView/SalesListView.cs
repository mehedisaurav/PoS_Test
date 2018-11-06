using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.ViewModel.SaleView
{
    public class SalesListView
    {
        public Guid SaleId { get; set; }
        public string SaleName { get; set; }
        public double Amount { get; set; }
        public double NoOfProducts { get; set; }
        public string SaleDate { get; set; }
    }
}
