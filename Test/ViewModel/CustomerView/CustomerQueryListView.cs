using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.ViewModel.CustomerView;

namespace Test.ViewModel
{
    public class CustomerQueryListView
    {
        public int Count { get; set; }
        public IQueryable<CustomerModelView> CustomerModelView { get; set; }    

    }
}
