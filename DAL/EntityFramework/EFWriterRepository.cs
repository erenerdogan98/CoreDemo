using DAL.Abstract;
using DAL.Context;
using DAL.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.EntityFramework
{
    public class EFWriterRepository : GenericRepository<Writer>, IWriterDAL
    {
        private readonly MyContext _context;
        public EFWriterRepository(MyContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(_context));
        }

        public async Task<List<Writer>> GetWriterByIdAsync(int id) => await CustomQueryWithIncludes(x => x.ID == id).ToListAsync();

        private IQueryable<Writer> CustomQueryWithIncludes(params Expression<Func<Writer, object>>[] includeProperties)
        {
            IQueryable<Writer> query = _context.Set<Writer>();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
