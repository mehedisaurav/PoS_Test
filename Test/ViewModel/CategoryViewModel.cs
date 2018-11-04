using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.ViewModel
{
    public class CategoryViewModel
    {
        public Guid CategoryId { get; set; }


        public string CategoryName { get; set; }

        public string Note { get; set; }

        public short? Status { get; set; }

        public DateTime Create { get; set; }

        public DateTime Modify { get; set; }

        public Guid CreateBy { get; set; }

        public Guid ModifyBy { get; set; }
    }
}
