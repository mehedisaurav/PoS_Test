using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PosService.IRepository;
using Repository;

namespace PosService.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly PosDbContext _posDbContext;

        public GenericRepository(PosDbContext posDbContext)
        {
            this._posDbContext = posDbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _posDbContext.Set<TEntity>().AsQueryable();
        }

        public async Task<TEntity> GetById(Guid Id)
        {
            return await _posDbContext.Set<TEntity>()
                .FindAsync(Id);
        }

        public async Task Create(TEntity entity)
        {
             _posDbContext.Set<TEntity>().AddAsync(entity);
            await _posDbContext.SaveChangesAsync();
        }

        public async Task Update( TEntity entity)
        {
             _posDbContext.Set<TEntity>().Update(entity);
            await _posDbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid Id)
        {
            var entity = await GetById(Id);
            _posDbContext.Set<TEntity>().Remove(entity);
            await _posDbContext.SaveChangesAsync();
        }
    }
}
