using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TOTVSChallenge.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T, in TPk> : IDisposable
    {
        T Save(T entity);

        IQueryable<T> NoTracking();

        Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetByIdAsync(Object id);

        Task DeleteAsync(int identifier);

        Task DeleteAsync(Expression<Func<T, bool>> predicate);
    }
}
