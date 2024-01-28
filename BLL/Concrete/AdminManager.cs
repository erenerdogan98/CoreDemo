using BLL.Abstract;
using DAL.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace BLL.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDAL _adminDAL;
        public AdminManager(IAdminDAL adminDAL)
        {
            _adminDAL = adminDAL ?? throw new ArgumentNullException(nameof(adminDAL));
        }
        public async Task AddAsync(Admin admin) => await _adminDAL.AddAsync(admin);

        public async Task DeleteAsync(Admin admin) => await _adminDAL.DeleteAsync(admin);

        public async Task<IEnumerable<Admin>> GetAllAsync() => await _adminDAL.GetAllAsync();

        public async Task<IEnumerable<Admin>> GetAllAsync(Expression<Func<Admin, bool>> filter) => await _adminDAL.GetAllAsync(filter);

        public async Task<Admin> GetByIdAsync(int id) => await _adminDAL.GetByIdAsync(id);

        public async Task UpdateAsync(Admin admin) => await _adminDAL.UpdateAsync(admin);
    }
}
