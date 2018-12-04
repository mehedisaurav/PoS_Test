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
using Test.ViewModel.ProductView;

namespace Test.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly PosDbContext _posDbContext ;

        public ProductRepository(PosDbContext dbContext) : base(dbContext)
        {
            _posDbContext = dbContext;
        }



        public async Task CreateProduct(ProductSaveUpdateModelView model)
        {
            Product product = new Product();

            product.ProductId = Guid.NewGuid();
            product.Create = DateTime.UtcNow;
            product.Modify = DateTime.UtcNow;
            product.CreateBy = Guid.NewGuid();
            product.ModifyBy = Guid.NewGuid();

            product.Name = model.Name;
            product.Price = model.Price;
            product.Quantity = model.Quantity;
            product.UnitMeasurement = model.MeasureType;
            product.Category = _posDbContext.Categories.Where(x => x.CategoryId == model.Category.CategoryId).FirstOrDefault();
            product.CategoryId = model.Category.CategoryId;
            
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

        public async Task UpdateProduct(ProductSaveUpdateModelView product)
        {
            Product oldProduct = _posDbContext.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();

            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;
            oldProduct.Quantity = product.Quantity;
            oldProduct.UnitMeasurement = product.MeasureType;
            oldProduct.Category = _posDbContext.Categories.Where(x => x.CategoryId == product.Category.CategoryId).FirstOrDefault();
            oldProduct.Modify = DateTime.Now;

            await Update(oldProduct);
        }
    }
}
