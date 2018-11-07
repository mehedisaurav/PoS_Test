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

        public double Due { get; set; }

        public double Paid { get; set; }

        public string Note { get; set; }

        public Guid? SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }  

        public ICollection<PurchaseDetails> PurchaseDetailses { get; set; }    
    }
}
