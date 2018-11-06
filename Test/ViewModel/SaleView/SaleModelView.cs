using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.ViewModel.SaleDetails;

namespace Test.ViewModel.SaleView
{
    public class SaleModelView
    {
        public Guid Id { get; set; }
        public double TotalAmount { get; set; }
        public int NoOfProduct { get; set; }
        public double? VAT { get; set; }
        public double? Discount { get; set; }
        public List<SaleDetailsViewModel> SaleDetails { get; set; }
    }
}
