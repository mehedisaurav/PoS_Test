using PosService.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Model;
using Test.ViewModel;
using Test.ViewModel.ListViewModel;

namespace Test.IRepository
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        Task<SupplierQueryListView> GetAllSupplierTask(SupplierViewListModel query);
        Task CreateSupplier(SupplierModelView Supplier);
        Task UpdateSupplier(SupplierModelView Supplier);
        Task<SupplierModelView> SupplierDetails(Guid Id);
    }
}
