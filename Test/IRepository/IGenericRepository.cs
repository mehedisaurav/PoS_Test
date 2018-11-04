using Microsoft.AspNetCore.Server.Kestrel.Internal.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosService.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(Guid Id);

        Task Create(TEntity entity);

        Task Update( TEntity entity);

        Task Delete(Guid Id);
    }
}
