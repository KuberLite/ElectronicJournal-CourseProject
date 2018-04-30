using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using electronic_journal.DAL.EF;

namespace electronic_journal.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query();

        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);

        Task<TEntity> GetById(Guid id);

        Task<TEntity> Create(TEntity item);

        Task Update(TEntity item);

        Task<TEntity> Remove(Guid id);
    }
}
