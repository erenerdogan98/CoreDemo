
using Entities.Concrete;
using System.Linq.Expressions;

namespace DAL.Abstract
{
    public interface IGenericDAL<T> where T : class , IEntityBase, new()
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> List(Expression<Func<T, bool>> filter);
    }
}
/* 
 where T : class, IEntityBase, new() expression satisfies the following conditions:

T must be a reference type (class).
T must implement the IEntityBase interface.
Type T must have a parameterless constructor (new()).
 */