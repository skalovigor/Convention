using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Convention.Common.Repository
{
    public abstract class Repository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : class
    {
        public Repository(DbSet<TEntity> dbSet)
        {
            DbSet = dbSet;
        }

        protected DbSet<TEntity> DbSet { get; }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            return await DbSet.FindAsync(id);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> whereExpression)
        {
            return DbSet.FirstOrDefaultAsync(whereExpression);
        }

        public async Task<IReadOnlyCollection<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await DbSet.Where(whereExpression).ToListAsync();
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }
    }
}