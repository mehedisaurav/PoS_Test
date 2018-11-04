using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Test.Model;

namespace Repository.Model
{
    public class Category : Entity
    {
      
        public Guid CategoryId { get; set; }

     
        public string CategoryName { get; set; }

        public string Note { get; set; }

        public short? Status { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
