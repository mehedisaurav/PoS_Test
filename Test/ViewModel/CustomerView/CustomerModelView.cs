using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.ViewModel.CustomerView
{
    public class CustomerModelView
    {
        public Guid CustomerId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public double Due { get; set; }

        public double Paid { get; set; }
    }
}
