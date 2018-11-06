using PosService.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Model;
using Test.ViewModel.ListViewModel;
using Test.ViewModel.SaleView;

namespace Test.IRepository
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        Task<SaleQueryListView> GetAllSaleTask(SaleViewListModel query);
        Task CreateSale(SaleModelView sale);
        Task UpdateSale(SaleModelView sale);
        Task<SaleModelView> SaleDetails(Guid Id);
    }
}
