using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.ViewModel.CategoryView
{
    public class CategoryQueryListView
    {
        public int Count { get; set; }
        public IQueryable<CategoryViewModel> CategoryViewModel { get; set; }

    }
}
