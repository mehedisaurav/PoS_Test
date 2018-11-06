using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.IRepository;
using Test.ViewModel.ListViewModel;
using Test.ViewModel.SaleView;

namespace Test.Controllers
{
    [Produces("application/json")]
    [Route("api/Sale")]
    public class SaleController : Controller
    {

        private readonly ISaleRepository _repository;

        public SaleController(ISaleRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("SaleAll")]
        public async Task<SaleQueryListView> GetAllSale([FromBody] SaleViewListModel query)
        {
            var sales = await this._repository.GetAllSaleTask(query);
            return sales;
        }


        [HttpPost]
        [Route("SaveSale")]
        public async Task<IActionResult> SaveSale([FromBody]SaleModelView sale)
        {
            await this._repository.CreateSale(sale);
            return Ok("Success");
        }

        [HttpGet]
        [Route("GetSale/Id")]
        public async Task<SaleModelView> GetSaleDetailById(Guid Id)
        {
            var detail = await _repository.SaleDetails(Id);
            return detail;
        }


        [HttpPut]
        [Route("UpdateSale")]
        public async Task<IActionResult> UpdateSale([FromBody]SaleModelView sale)
        {
            await this._repository.UpdateSale(sale);
            return Ok("Success");
        }
    }
}