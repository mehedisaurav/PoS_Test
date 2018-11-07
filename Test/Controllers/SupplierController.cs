using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.IRepository;
using Test.ViewModel;
using Test.ViewModel.ListViewModel;

namespace Test.Controllers
{
    [Produces("application/json")]
    [Route("api/Supplier")]
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierController(ISupplierRepository _repository)
        {
            _supplierRepository = _repository;
        }

        [HttpPost]
        [Route("GetResult")]
        public async Task<SupplierQueryListView> GetResult([FromBody]SupplierViewListModel query)
        {

            return await _supplierRepository.GetAllSupplierTask(query);
        }

        [HttpGet]
        [Route("GetDetails/Id")]
        public async Task<SupplierModelView> GetDetails(Guid Id)
        {
            var details = await _supplierRepository.SupplierDetails(Id);
            return details;
        }

        [HttpPost]
        [Route("CreateSupplier")]
        public async Task<IActionResult> CreateSupplier([FromBody]SupplierModelView supplier)
        {
            await _supplierRepository.CreateSupplier(supplier);

            return Ok("Create Success");
        }


        [HttpPut]
        [Route("SupplierUpdate")]
        public async Task<IActionResult> CustomerUpdate([FromBody]SupplierModelView supplier)
        {
            await _supplierRepository.UpdateSupplier(supplier);
            return Ok("Update Successfully");
        }

    }
}