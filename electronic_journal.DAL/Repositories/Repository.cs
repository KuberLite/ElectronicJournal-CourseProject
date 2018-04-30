using electronic_journal.DAL.EF;
using electronic_journal.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace electronic_journal.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Query()
        {
            return _dbSet;
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> Create(TEntity item)
        {
            TEntity entity = _dbSet.Add(item);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(TEntity item)
        {
            _dbSet.AddOrUpdate(item);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> Remove(Guid id)
        {
            TEntity entity = _dbSet.Remove(_dbSet.Find(id));
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
