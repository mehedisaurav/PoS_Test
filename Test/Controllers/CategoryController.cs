using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PosService.IRepository;
using Repository.Model;
using Test.ViewModel;
using Test.ViewModel.CategoryView;
using Test.ViewModel.ListViewModel;

namespace Test.Controllers
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetDetails/Id")]
        public async Task<CategoryViewModel> GetDetails(Guid Id)
        {
            var details = await _repository.CategoryDetails(Id);
            return details;
        }

        [HttpPost]
        [Route("GetResult")]
        public async Task<CategoryQueryListView>  GetResult([FromBody]CategoryViewListModel query)
        {
                
            return await _repository.GetAllCategoryTask(query);
        }

        

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody]Category category)
        {
             await _repository.CreateCategory(category);

            return Ok();
        }

        [HttpPut]
        [Route("CategoryUpdate")]
        public async Task<IActionResult> CategoryUpdate([FromBody]Category category)
        {
             await _repository.UpdateCategory(category);
            return Ok();
        }

        [HttpGet]
        [Route("CategoryDropList")]
        public async Task<IQueryable<CategoryDropdownList>> CateDropList()
        {
            var list = await _repository.CateDropList();
            return list;
        }

        [HttpGet]
        [Route("CategoryDropdownListByName/name")]
        public async Task<IQueryable<CategoryDropdownList>> CategoryDropdownListByName(string name)
        {
            var List = await _repository.CategoryListDropdown(name);

            return List;
        }

    }

   
}