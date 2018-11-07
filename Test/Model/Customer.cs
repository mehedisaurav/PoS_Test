using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Customer : Entity
    {
        public Guid CustomerId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public double Due { get; set; }

        public double Paid { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }


    }
}
