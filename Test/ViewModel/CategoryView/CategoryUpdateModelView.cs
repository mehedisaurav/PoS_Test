using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.ViewModel.CategoryView
{
    public class CategoryUpdateModelView
    {
        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Note { get; set; }
    }
}
