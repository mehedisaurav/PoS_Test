using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PosService.IRepository;
using Repository.Model;
using Test.Model;
using Test.ViewModel;
using Test.ViewModel.ListViewModel;
using Test.ViewModel.ProductView;

namespace Test.IRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<ProductQueryListView> GetAllProductTask(ProductViewListModel query);
        Task CreateProduct(ProductSaveUpdateModelView product);
        Task UpdateProduct(ProductSaveUpdateModelView product);
        Task<ProductViewModel> ProductDetails(Guid Id);
    }
}
