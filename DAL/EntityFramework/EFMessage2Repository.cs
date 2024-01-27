using DAL.Abstract;
using DAL.Context;
using DAL.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.EntityFramework
{
    public class EFMessage2Repository : GenericRepository<Message2> , IMessage2DAL
    {
        private readonly MyContext _context;
        public EFMessage2Repository(MyContext context) : base(context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Message2>> GetListWithMessageByWriterAsync(int id) => await CustomQueryWithIncludes(x => x.ReceiverUser)
            .Where(x => x.ReceiverID == id)
            .ToListAsync();

        private IQueryable<Message2> CustomQueryWithIncludes(params Expression<Func<Message2, object>>[] includeProperties)
        {
            IQueryable<Message2> query = _context.Set<Message2>();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
