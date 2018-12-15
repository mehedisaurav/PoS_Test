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
            cateList = cateList.Skip(query.Page * query.Size).Take(query.Size).OrderByDescending(s=>s.Modify);
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


        public async Task CreateCategory(CategorySaveUpdateModelView category)
        {
            Category newCategory = new Category()
            {
                CategoryName = category.CategoryName,
                Note = category.Note,
                CategoryId = Guid.NewGuid(),
                Create = DateTime.UtcNow,
                Modify = DateTime.UtcNow,
                CreateBy = Guid.NewGuid(),
                ModifyBy = Guid.NewGuid(),
                Status = 1,
        };

            
            await Create(newCategory);

        }

        public async Task UpdateCategory(CategorySaveUpdateModelView category)
        {
            if (category.CategoryId != null)
            {
                Category oldCategory = _context.Categories.Where(x => x.CategoryId == category.CategoryId).FirstOrDefault();


                oldCategory.CategoryId = category.CategoryId.Value;
                oldCategory.CategoryName = category.CategoryName;
                oldCategory.Note = category.Note;
                oldCategory.Modify = DateTime.UtcNow;


                await Update(oldCategory);
            }
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
            var list = _context.Categories.Where(x => x.CategoryName.Contains(name));
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


        public async Task<bool> CategoryCheckFordublicateByName(string name)
        {
            var result = _context.Categories.Where(x => x.CategoryName == name).FirstOrDefault();


            return result!=null ? true : false;
        }

    }
}
