using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PosService.IRepository;
using Repository;
using Repository.Model;
using Test.ViewModel;
using Test.ViewModel.CategoryView;
using Test.ViewModel.ListViewModel;

namespace PosService.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly PosDbContext _context;

        public CategoryRepository(PosDbContext _dbContext) : base(_dbContext)
        {
            _context = _dbContext;
        }


        public async Task<CategoryQueryListView> GetAllCategoryTask(CategoryViewListModel query)
        {

            CategoryQueryListView queryList = new CategoryQueryListView();

            var cateList =  GetAll().OrderByDescending(x => x.Modify) ;
            queryList.Count = cateList.Count();
            cateList = cateList.Skip(query.Page * query.Size).Take(query.Size).OrderBy(s=>s.CategoryName);
            var list = new List<CategoryViewModel>();
            foreach (Category category in cateList)
            {
                var cate = new CategoryViewModel()
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Note = category.Note,
                    Status = category.Status,
                    Create = category.Create,
                    CreateBy = category.CreateBy,
                    Modify = category.Modify,
                    ModifyBy = category.ModifyBy
                };

                list.Add(cate);
            }
            queryList.CategoryViewModel = list.AsQueryable();
            return queryList;
        }

        public async Task<CategoryViewModel> CategoryDetails(Guid Id)
        {
            var category = await GetById(Id);
            var catgDetail = new CategoryViewModel()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Status = category.Status,
                Note = category.Note,
                Create = category.Create,
                CreateBy = category.CreateBy,
                Modify = category.Modify,
                ModifyBy = category.ModifyBy
            };

            return catgDetail;
        }


        public async Task CreateCategory(Category category)
        {
            category.CategoryId = Guid.NewGuid();
            category.Create = DateTime.UtcNow;
            category.Modify = DateTime.UtcNow;
            category.CreateBy = Guid.NewGuid();
            category.ModifyBy = Guid.NewGuid();
            category.Status = 1;
            await Create(category);

        }

        public async Task UpdateCategory(Category category)
        {
            var catg = new Category()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Note = category.Note,
                Status = category.Status,
                Modify = DateTime.UtcNow,
                Create = category.Create,
                CreateBy = category.CreateBy,
                ModifyBy = category.ModifyBy
            };

            await Update(catg);
        }

        public async Task<IQueryable<CategoryDropdownList>> CateDropList()
        {
            var cateList = _context.Categories.ToList();
            var List = new List<CategoryDropdownList>();

            foreach (Category category in cateList)
            {
                var cate = new CategoryDropdownList()
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                };

                List.Add(cate);
            }

            return List.AsQueryable().OrderBy(x => x.CategoryName);
        }

        public async Task<IQueryable<CategoryDropdownList>> CategoryListDropdown(string name)
        {
            var list = _context.Categories.Where(x => x.CategoryName.StartsWith(name));
            var List = new List<CategoryDropdownList>();

            foreach (Category category in list)
            {
                var cate = new CategoryDropdownList()
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                };

                List.Add(cate);
            }

            return List.AsQueryable().OrderBy(x => x.CategoryName);

        }

    }
}
