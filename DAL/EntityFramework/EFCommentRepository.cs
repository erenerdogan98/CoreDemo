using DAL.Abstract;
using DAL.Context;
using DAL.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.EntityFramework
{
    public class EFCommentRepository : GenericRepository<Comment>, ICommentDAL
    {
        private readonly MyContext _context;
        public EFCommentRepository(MyContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        private IQueryable<Comment> CustomQueryWithIncludes(params Expression<Func<Comment, object>>[] includeProperties)
        {
            IQueryable<Comment> query = _context.Set<Comment>();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        public async Task<List<Comment>> GetListWithBlogAsync() => await CustomQueryWithIncludes(x => x.Blog).ToListAsync();
    }
}
