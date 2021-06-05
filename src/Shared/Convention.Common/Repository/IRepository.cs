using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Convention.Common.Repository
{
    public interface IRepository<TKey, T>
        where T : class
    {
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> whereExpression);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<T> GetAsync(TKey id);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
    }
}