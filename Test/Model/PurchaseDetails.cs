using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Model
{
    public class PurchaseDetails
    {
        public Guid PurchaseDetailsId { get; set; }

        public Guid PurchaseId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public string MeasureType { get; set; }

        public double Price { get; set; }

        public Product Product { get; set; }

        public Purchase Purchase { get; set; }
    }
}
