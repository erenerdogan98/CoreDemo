using DAL.Abstract;
using DAL.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace DAL.EntityFramework
{
    public class EFUserRepository : IUserDAL<AppUser>
    {
        private readonly MyContext _context;
        public EFUserRepository(MyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        private IQueryable<AppUser> QueryWithIncludes(params Expression<Func<AppUser, object>>[] includeProperties)
        {
            IQueryable<AppUser> query = _context.Set<AppUser>();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        public async Task AddAsync(AppUser appUser)
        {
            await _context.Set<AppUser>().AddAsync(appUser);
            SaveChangesAsync();
        }

        public async Task DeleteAsync(AppUser appUser)
        {
            _context.Remove(appUser);
            SaveChangesAsync();
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync() => await QueryWithIncludes().ToListAsync();
        public async Task<IEnumerable<AppUser>> GetAllAsync(Expression<Func<AppUser, bool>> filter) => await QueryWithIncludes().Where(filter).ToListAsync();

        public async Task<AppUser> GetByIdAsync(int id) => await QueryWithIncludes().FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(AppUser appUser)
        {
            EntityEntry entityEntry = _context.Entry<AppUser>(appUser);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
