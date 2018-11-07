using PosService.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.IRepository;
using Test.Model;
using Test.ViewModel;
using Test.ViewModel.ListViewModel;

namespace Test.Repository
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        private readonly PosDbContext _posDbContext;

        public SupplierRepository(PosDbContext _dbContext) : base(_dbContext)
        {
            _posDbContext = _dbContext;
        }

        public async Task CreateSupplier(SupplierModelView model)
        {
            Supplier supplier = new Supplier();

            supplier.SupplierId = Guid.NewGuid();
            supplier.Name = model.Name;
            supplier.Note = model.Note;
            supplier.Address = model.Address;
            supplier.Phone = model.Phone;
            supplier.Email = model.Email;
            supplier.Company = model.Company;
            supplier.Due = model.Due;
            supplier.Paid = model.Paid;
            supplier.Create = DateTime.Now;
            supplier.CreateBy = Guid.NewGuid();
            supplier.Modify = DateTime.Now;
            supplier.ModifyBy = Guid.NewGuid();

            await Create(supplier);
        }

        public async Task<SupplierQueryListView> GetAllSupplierTask(SupplierViewListModel query)
        {
            SupplierQueryListView queryList = new SupplierQueryListView();

            var supplierList = GetAll().OrderByDescending(x => x.Modify);
            //custList = custList.Where(x => x.Name.Contains(query.Search) || x.Phone.StartsWith(query.Search)).OrderBy(p => p.Name);
            queryList.Count = supplierList.Count();
            supplierList = supplierList.Skip(query.Page * query.Size).Take(query.Size).OrderByDescending(s => s.Modify);
            var list = new List<SupplierModelView>();
            foreach (Supplier supp in supplierList)
            {
                var supplier = new SupplierModelView()
                {
                    SupplierId = supp.SupplierId,
                    Name = supp.Name,
                    Address = supp.Address,
                    Email = supp.Email,
                    Due = supp.Due,
                    Paid = supp.Paid,
                    Phone = supp.Phone,
                    Company = supp.Company,
                    Note = supp.Note
                };

                list.Add(supplier);
            }
            queryList.SupplierModelView = list.AsQueryable();
            return queryList;
        }

        public async Task<SupplierModelView> SupplierDetails(Guid Id)
        {
            Supplier supplier = await GetById(Id);


            if(supplier != null)
            {

                return new SupplierModelView()
                {
                    SupplierId = supplier.SupplierId,
                    Name = supplier.Name,
                    Address = supplier.Address,
                    Company = supplier.Company,
                    Email = supplier.Email,
                    Phone = supplier.Phone,
                    Note = supplier.Note,
                    Due = supplier.Due,
                    Paid = supplier.Paid
                };
            }

            return null;

        }

        public async Task UpdateSupplier(SupplierModelView supplier)
        {
            Supplier oldSupplier = await GetById(supplier.SupplierId);

            oldSupplier.Name = supplier.Name;
            oldSupplier.Address = supplier.Address;
            oldSupplier.Company = supplier.Company;
            oldSupplier.Email = supplier.Email;
            oldSupplier.Phone = supplier.Phone;
            oldSupplier.Note = supplier.Note;
            oldSupplier.Due = supplier.Due;
            oldSupplier.Paid = supplier.Paid;
            oldSupplier.Modify = DateTime.Now;

            await Update(oldSupplier);
        }
    }
}
