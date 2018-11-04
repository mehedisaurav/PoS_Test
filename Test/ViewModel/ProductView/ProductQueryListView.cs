using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.ViewModel.ListViewModel
{
    public class ProductQueryListView
    {
        public int Count { get; set; }
        public IQueryable<ProductViewModel> ProductviewModel { get; set; }

    }
}
