using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Convention.Common.Repository
{
    public abstract class Repository<TKey, T> : IRepository<TKey, T>
        where T : class
    {
        public Repository(DbSet<T> dbSet)
        {
            DbSet = dbSet;
        }

        protected DbSet<T> DbSet { get; }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual async Task<T> GetAsync(TKey id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> whereExpression)
        {
            return await DbSet.Where(whereExpression).ToListAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }
    }
}