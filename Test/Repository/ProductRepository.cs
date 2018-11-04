using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PosService.Repository;
using Repository;
using Test.IRepository;
using Test.Model;
using Test.ViewModel;
using Test.ViewModel.ListViewModel;

namespace Test.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly PosDbContext _posDbContext ;

        public ProductRepository(PosDbContext dbContext) : base(dbContext)
        {
            _posDbContext = dbContext;
        }



        public async Task CreateProduct(Product product)
        {
            product.ProductId = Guid.NewGuid();
            product.Create = DateTime.UtcNow;
            product.Modify = DateTime.UtcNow;
            product.CreateBy = Guid.NewGuid();
            product.ModifyBy = Guid.NewGuid();
            
            await Create(product);
        }

        public async Task<ProductQueryListView> GetAllProductTask(ProductViewListModel query)
        {
            ProductQueryListView queryList = new ProductQueryListView();
            queryList.Count = GetAll().Include(x => x.Category).Count();
            var prodAll = GetAll().Include(x => x.Category).Skip(query.Size * query.Page).Take(query.Size).ToList();
            var list = new List<ProductViewModel>();


            foreach (Product product in prodAll)
            {
                var prod = new ProductViewModel();
                prod.Name = product.Name;
                prod.CategoryId = product.CategoryId;
                prod.ProductId = product.ProductId;
                prod.Price = product.Price;
                prod.Quantity = product.Quantity;
                prod.UnitMeasurement = product.UnitMeasurement;
                prod.Category = product.Category.CategoryName;
                list.Add(prod);
            }
            queryList.ProductviewModel = list.AsQueryable();

            return queryList;
        }

        public async Task<ProductViewModel> ProductDetails(Guid Id)
        {
            Product product = await GetById(Id);

            return new ProductViewModel()
            {
                CategoryId = product.CategoryId,
                Name = product.Name,
                Price = product.Price,
                ProductId = product.ProductId,
                Quantity = product.Quantity,
                UnitMeasurement = product.UnitMeasurement
            };
        }

        public async Task UpdateProduct(Product product)
        {
            await Update(product);
        }
    }
}
