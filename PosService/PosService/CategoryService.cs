using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Repository.Model;

namespace PosService.PosService
{
    public class CategoryService
    {
        private static PosDbContext Context;

        public async Task<bool> CreateCategory(Category model)
        {

             Context.Add(model);
             
            return await Context.SaveChangesAsync() == 1 ? true : false ;
        }
    }
}
