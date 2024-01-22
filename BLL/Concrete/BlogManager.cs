using BLL.Abstract;
using DAL.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace BLL.Concrete
{
	public class BlogManager : IBlogService
	{
		private readonly IBlogDAL _blogDAL;
        public BlogManager(IBlogDAL blogDAL)
        {
            _blogDAL = blogDAL;
        }
        public async Task AddAsync(Blog blog) => await _blogDAL.AddAsync(blog);

		public async Task DeleteAsync(Blog blog) => await _blogDAL.DeleteAsync(blog);

		public async Task<IEnumerable<Blog>> GetAllAsync() => await _blogDAL.GetAllAsync();

		public async Task<Blog> GetByIdAsync(int id) => await _blogDAL.GetByIdAsync(id);

        public async Task<List<Blog>> GetListWithCategoryAsync() => await _blogDAL.GetListWithCategoryAsync();

		public async Task<IEnumerable<Blog>> GetAllAsync(Expression<Func<Blog, bool>> filter) => await _blogDAL.GetAllAsync(filter);

		public async Task UpdateAsync(Blog blog) => await _blogDAL.UpdateAsync(blog);

		public async Task<List<Blog>> GetBlogsByWriterAsync(int id) => await _blogDAL.GetBlogsByWriterAsync(id);
	}
}
