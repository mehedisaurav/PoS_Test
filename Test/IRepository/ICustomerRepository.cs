using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Model;
using Test.Model;
using Test.ViewModel;
using Test.ViewModel.CustomerView;
using Test.ViewModel.ListViewModel;

namespace PosService.IRepository
{
    public interface ICustomerRepository :IGenericRepository<Customer>
    {
        Task<CustomerQueryListView> GetAllCustomerTask(CustomerViewListModel query);
        Task CreateCustomer(CustomerModelView Customer);
        Task UpdateCustomer(CustomerModelView Customer);
        Task<CustomerModelView> CustomerDetails(Guid Id);
    }
}
