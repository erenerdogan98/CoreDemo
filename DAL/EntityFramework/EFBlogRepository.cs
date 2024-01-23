using DAL.Abstract;
using DAL.Context;
using DAL.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.EntityFramework
{
    public class EFBlogRepository : GenericRepository<Blog>, IBlogDAL
    {
        private readonly MyContext _context;
        public EFBlogRepository(MyContext context) : base(context)
        {
            _context = context;
        }
        private IQueryable<Blog> CustomQueryWithIncludes(params Expression<Func<Blog, object>>[] includeProperties)
        {
            IQueryable<Blog> query = _context.Set<Blog>();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public async Task<List<Blog>> GetListWithCategoryAsync() => await CustomQueryWithIncludes(x => x.Category).ToListAsync();

        public async Task<List<Blog>> GetBlogsByWriterAsync(int id) => await CustomQueryWithIncludes(x => x.WriterID == id).ToListAsync();

        public async Task<List<Blog>> GetListWithCategoryAsync(int id) => await CustomQueryWithIncludes(x => x.CategoryID == id).ToListAsync();
    }
}
