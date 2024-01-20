using BLL.Abstract;
using DAL.Abstract;
using Entities.Concrete;

namespace BLL.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;
        public async Task AddAsync(Category category) => await _categoryDAL.AddAsync(category);


        public async Task DeleteAsync(Category category) => await _categoryDAL.DeleteAsync(category);

        public async Task<IEnumerable<Category>> GetAllAsync() => await _categoryDAL.GetAllAsync();

        public async Task<Category> GetByIdAsync(int id) => await _categoryDAL.GetByIdAsync(id);

        public async Task UpdateAsync(Category category) => await _categoryDAL.UpdateAsync(category);
    }
}
