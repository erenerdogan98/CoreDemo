using Entities.Concrete;
using System.Linq.Expressions;

namespace DAL.Abstract
{
    public interface IUserDAL<T>
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter);
    }
}
