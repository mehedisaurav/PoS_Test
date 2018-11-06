using PosService.IRepository;
using PosService.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.IRepository;
using Test.Model;
using Test.ViewModel.ListViewModel;
using Test.ViewModel.SaleDetails;
using Test.ViewModel.SaleView;

namespace Test.Repository
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly PosDbContext _context;

        public SaleRepository(PosDbContext _dbContext) : base(_dbContext)
        {
            _context = _dbContext;
        }



        public async Task CreateSale(SaleModelView model)
        {
            Sale create = new Sale
            {
                SaleId = Guid.NewGuid(),
                TotalAmount = model.TotalAmount,
                NoOfItem = model.NoOfProduct,
                Create = DateTime.Now,
                Modify = DateTime.Now,
                Note = "",
                CreateBy = Guid.NewGuid(),
                ModifyBy = Guid.NewGuid()
                
            };
            await Create(create);

            
            if (create.SaleId != null)
            {
                foreach (SaleDetailsViewModel item in model.SaleDetails)
                {
                    SaleDetails product = new SaleDetails();
                    product.SaleId = create.SaleId;
                    product.Quantity = item.Quantity;
                    product.ProductId = item.ProductId;
                    product.Price = item.Price;
                    product.MeasureType = item.Unit.ToString();
                    product.Create = DateTime.Now;
                    product.CreateBy = Guid.NewGuid();
                    product.Modify = DateTime.Now;
                    product.ModifyBy = Guid.NewGuid();

                    _context.Set<SaleDetails>().AddAsync(product);                    
                    
                }
            }
            await _context.SaveChangesAsync();

        }

        public async Task<SaleQueryListView> GetAllSaleTask(SaleViewListModel query)
        {
            SaleQueryListView queryList = new SaleQueryListView();
            queryList.Count = GetAll().Count();
            var saleAll = GetAll().Skip(query.Size * query.Page).Take(query.Size).ToList();

            List<SalesListView> list = new List<SalesListView>();

            foreach (Sale sale in saleAll)
            {
                var sales = new SalesListView();
                sales.SaleId = sale.SaleId;
                sales.NoOfProducts = sale.NoOfItem;
                sales.Amount = sale.TotalAmount;
                sales.SaleName = "";
                sales.SaleDate = sale.Create.ToString("MM/dd/yyyy h:mm tt");
                list.Add(sales);
            }
            queryList.listView = list;
            return queryList;
        }

        public async Task<SaleModelView> SaleDetails(Guid Id)
        {
            Sale detailsSale = await GetById(Id);
            var salesDetails = _context.SaleDetailses.Where(x => x.SaleId == Id).ToList();
            
            List<SaleDetailsViewModel> detailsList = new List<SaleDetailsViewModel>();

            foreach (SaleDetails item in salesDetails)
            {
                detailsList.Add(new SaleDetailsViewModel {
                    Price = item.Price,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Unit = Convert.ToInt32(item.MeasureType)
                });
            }


            return new SaleModelView()
            {
                Id= Id,
                SaleDetails = detailsList,
                NoOfProduct = detailsSale.NoOfItem,
                TotalAmount = detailsSale.TotalAmount
            };
        }

        public async Task UpdateSale(SaleModelView model)
        {
            Sale oldDetailSale = await GetById(model.Id);
            List<SaleDetails> saleDetailList = _context.SaleDetailses.Where(x => x.SaleId == model.Id).ToList();

            foreach (SaleDetails item in saleDetailList)
            {
                _context.Set<SaleDetails>().Remove(item);
            }
            _context.SaveChangesAsync();

            oldDetailSale.Modify = DateTime.Now;
            oldDetailSale.NoOfItem = model.NoOfProduct;
            oldDetailSale.TotalAmount = model.TotalAmount;

            await Update(oldDetailSale);

            if (model.Id != null)
            {
                foreach (SaleDetailsViewModel item in model.SaleDetails)
                {
                    SaleDetails product = new SaleDetails();
                    product.SaleId = model.Id;
                    product.Quantity = item.Quantity;
                    product.ProductId = item.ProductId;
                    product.Price = item.Price;
                    product.MeasureType = item.Unit.ToString();
                    product.Create = DateTime.Now;
                    product.CreateBy = Guid.NewGuid();
                    product.Modify = DateTime.Now;
                    product.ModifyBy = Guid.NewGuid();

                    _context.Set<SaleDetails>().AddAsync(product);

                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
