using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PosService.IRepository;
using Test.ViewModel;
using Test.ViewModel.CustomerView;
using Test.ViewModel.ListViewModel;

namespace Test.Controllers
{
    [Produces("application/json")]
    [Route("api/Customer")]
    public class CustomerController : Controller
    {

        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]
        [Route("GetResult")]
        public async Task<CustomerQueryListView> GetResult([FromBody]CustomerViewListModel query)
        {

            return await _repository.GetAllCustomerTask(query);
        }

        [HttpGet]
        [Route("GetDetails/Id")]
        public async Task<CustomerModelView> GetDetails(Guid Id)
        {
            var details = await _repository.CustomerDetails(Id);
            return details;
        }


        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody]CustomerModelView customer)
        {
            await _repository.CreateCustomer(customer);

            return Ok("Create Success");
        }

        [HttpPut]
        [Route("CustomerUpdate")]
        public async Task<IActionResult> CustomerUpdate([FromBody]CustomerModelView customer)
        {
            await _repository.UpdateCustomer(customer);
            return Ok("Update Successfully");
        }
    }
}