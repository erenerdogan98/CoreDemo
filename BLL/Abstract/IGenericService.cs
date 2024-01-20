using System.Linq.Expressions;

namespace BLL.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
		Task<IEnumerable<T>> List(Expression<Func<T, bool>> filter);
	}
}
