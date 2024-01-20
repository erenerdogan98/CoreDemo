
using Entities.Concrete;

namespace DAL.Abstract
{
    public interface IGenericDAL<T> where T : class , IEntityBase, new()
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
