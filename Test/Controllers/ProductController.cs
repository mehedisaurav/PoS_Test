using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PosService.IRepository;
using Test.IRepository;
using Test.Model;
using Test.ViewModel;
using Test.ViewModel.ListViewModel;
using Test.ViewModel.ProductView;

namespace Test.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        /* [HttpGet]
         [Route("")]*/
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("ProductAll")]
        public async Task<ProductQueryListView> GeetAllProduct([FromBody] ProductViewListModel query)
        {
            var products = await this._repository.GetAllProductTask(query);
            return products;
        }


        [HttpGet]
        [Route("GetProduct/Id")]
        public async Task<ProductViewModel> GetProductDetailById(Guid Id)
        {
            var detail = await _repository.ProductDetails(Id);
            return detail;
        }


        [HttpPost]
        [Route("SaveProduct")]
        public async Task<IActionResult> SaveProduct([FromBody]ProductSaveUpdateModelView product)
        {
            if(product != null)
            {
                await this._repository.CreateProduct(product);
                return Ok("Success");
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody]ProductSaveUpdateModelView product)
        {
            if (product != null)
            {
                await this._repository.UpdateProduct(product);
                return Ok("Success");
            }

            return BadRequest();
        }

    }
}