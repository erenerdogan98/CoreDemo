using BLL.Abstract;
using DAL.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace BLL.Concrete
{
    public class UserManager : IUserService<AppUser>
    {
        private readonly IUserDAL<AppUser> _userDAL;
        public UserManager(IUserDAL<AppUser> userDAL)
        {
            _userDAL = userDAL ?? throw new ArgumentNullException(nameof(userDAL));
        }

        public async Task AddAsync(AppUser appUser) => await _userDAL.AddAsync(appUser);

        public async Task DeleteAsync(AppUser appUser) => await _userDAL.DeleteAsync(appUser);

        public async Task<IEnumerable<AppUser>> GetAllAsync() => await _userDAL.GetAllAsync();

        public async Task<IEnumerable<AppUser>> GetAllAsync(Expression<Func<AppUser, bool>> filter) => await _userDAL.GetAllAsync(filter);

        public async Task<AppUser> GetByIdAsync(int id) => await _userDAL.GetByIdAsync(id);

        public async Task UpdateAsync(AppUser appUser) => await _userDAL.UpdateAsync(appUser);
    }
}
