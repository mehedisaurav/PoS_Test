using PosService.IRepository;
using PosService.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Model;
using Test.ViewModel;
using Test.ViewModel.CustomerView;
using Test.ViewModel.ListViewModel;

namespace Test.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly PosDbContext _posDbContext;

        public CustomerRepository(PosDbContext _dbContext) : base(_dbContext)
        {
            _posDbContext = _dbContext;
        }

        public async Task CreateCustomer(CustomerModelView Customer)
        {
            Customer customer = new Customer();

            customer.CustomerId = Guid.NewGuid();
            customer.Name = Customer.Name;
            customer.Address = Customer.Address;
            customer.Phone = Customer.Phone;
            customer.Paid = Customer.Paid;
            customer.Due = Customer.Due;
            customer.Email = Customer.Email;
            customer.Create = DateTime.Now;
            customer.CreateBy = Guid.NewGuid();
            customer.Modify = DateTime.Now;
            customer.ModifyBy = Guid.NewGuid();

            await Create(customer);
        }

        public async Task<CustomerModelView> CustomerDetails(Guid Id)
        {
            Customer customer = await GetById(Id);
            CustomerModelView detail = new CustomerModelView();
            if (customer != null)
            {
                detail = new CustomerModelView()
                {
                    CustomerId = customer.CustomerId,
                    Name = customer.Name,
                    Address = customer.Address,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Due = customer.Due,
                    Paid = customer.Paid
                };
            }

            return detail;
        }

        public async Task<CustomerQueryListView> GetAllCustomerTask(CustomerViewListModel query)
        {

            CustomerQueryListView queryList = new CustomerQueryListView();

            var custList = GetAll().OrderByDescending(x => x.Modify);
            custList = custList.Where(x => x.Name.Contains(query.Search) || x.Phone.StartsWith(query.Search)).OrderBy(p => p.Name);
            queryList.Count = custList.Count();
            custList = custList.Skip(query.Page * query.Size).Take(query.Size).OrderBy(s => s.Name);
            var list = new List<CustomerModelView>();
            foreach (Customer customer in custList)
            {
                var cust = new CustomerModelView()
                {
                    CustomerId = customer.CustomerId,
                    Name = customer.Name,
                    Address = customer.Address,
                    Email = customer.Email,
                    Due = customer.Due,
                    Paid = customer.Paid,
                    Phone = customer.Phone
                };

                list.Add(cust);
            }
            queryList.CustomerModelView = list.AsQueryable();
            return queryList;
        }

        public async Task UpdateCustomer(CustomerModelView Customer)
        {

            Customer customer =  await GetById(Customer.CustomerId);

            customer.Name = Customer.Name;
            customer.Address = Customer.Address;
            customer.Phone = Customer.Phone;
            customer.Email = Customer.Email;
            customer.Paid = Customer.Paid;
            customer.Due = Customer.Due;
            customer.Modify = DateTime.Now;

            await Update(customer);
        }
    }
}
