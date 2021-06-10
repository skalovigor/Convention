using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Convention.Common.Repository
{
    public interface IRepository<TKey, TEntity>
        where TEntity : class
    {
        Task<IReadOnlyCollection<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> whereExpression);
        Task<IReadOnlyCollection<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TKey id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> whereExpression);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}