using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        IEnumerable<T> GetAll();
        Task<T> GetAsync(T id);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] Includes);
        Task<T> GetByIdAsync(T id, params Expression<Func<T, object>>[] Includes);
        Task AddAsync(T entity);
        Task UpdateAsync(T id, T entity);
        Task DeleteAsync(T id);





    }

}
