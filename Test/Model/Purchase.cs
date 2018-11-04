using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Model;

namespace Test.Model
{
    public class Purchase : Entity
    {
        public Guid PurchaseId { get; set; }

        public int NoOfItem { get; set; }

        public double TotalAmount { get; set; }

        public string Note { get; set; }

        public ICollection<PurchaseDetails> PurchaseDetailses { get; set; }    
    }
}
