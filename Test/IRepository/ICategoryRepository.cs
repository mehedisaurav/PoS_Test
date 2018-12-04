using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Model;
using Test.ViewModel;
using Test.ViewModel.CategoryView;
using Test.ViewModel.ListViewModel;

namespace PosService.IRepository
{
    public interface ICategoryRepository :IGenericRepository<Category>
    {
        Task<CategoryQueryListView> GetAllCategoryTask(CategoryViewListModel query);
        Task CreateCategory(CategorySaveUpdateModelView category);
        Task UpdateCategory(CategorySaveUpdateModelView category);
        Task<CategoryViewModel> CategoryDetails(Guid Id);
        Task<IQueryable<CategoryDropdownList>> CateDropList();
        Task<IQueryable<CategoryDropdownList>> CategoryListDropdown(string name);
        Task<bool> CategoryCheckFordublicateByName(string name);
    }
}
