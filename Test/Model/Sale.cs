using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Model;

namespace Test.Model
{
    public class Sale : Entity
    {
        public Guid SaleId { get; set; }

        public int NoOfItem { get; set; }

        public double TotalAmount { get; set; }

        public string Note { get; set; }

        public ICollection<SaleDetails> SaleDetailses { get; set; }
    }
}
