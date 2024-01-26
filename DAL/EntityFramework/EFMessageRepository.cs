using DAL.Abstract;
using DAL.Context;
using DAL.Repositories;
using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.EntityFramework
{
    public class EFMessageRepository : GenericRepository<Message> , IMessageDAL
    {
        private readonly MyContext _context;
        public EFMessageRepository(MyContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Message>> GetInBoxListByWriter(string receiver) => await CustomQueryWithIncludes(x => x.Receiver == receiver).ToListAsync();

        private IQueryable<Message> CustomQueryWithIncludes(params Expression<Func<Message, object>>[] includeProperties)
        {
            IQueryable<Message> query = _context.Set<Message>();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
