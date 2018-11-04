using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Model
{
    public class Entity
    {
        public DateTime Create { get; set; }

        public DateTime Modify { get; set; }

        public Guid CreateBy { get; set; }

        public Guid ModifyBy { get; set; }
    }
}
