using BLL.Abstract;
using DAL.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace BLL.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDAL _aboutDAL;
        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL ?? throw new ArgumentNullException(nameof(_aboutDAL));
        }
        public async Task AddAsync(About about) => await _aboutDAL.AddAsync(about);

        public async Task DeleteAsync(About about) => await _aboutDAL.DeleteAsync(about);

        public async Task<IEnumerable<About>> GetAllAsync() => await _aboutDAL.GetAllAsync();

        public async Task<IEnumerable<About>> GetAllAsync(Expression<Func<About, bool>> filter) => await _aboutDAL.GetAllAsync(filter);

        public async Task<About> GetByIdAsync(int id) => await _aboutDAL.GetByIdAsync(id);

        public async Task UpdateAsync(About about) => await _aboutDAL.UpdateAsync(about);
    }
}
