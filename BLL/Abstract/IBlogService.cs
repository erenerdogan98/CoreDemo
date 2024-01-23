using Entities.Concrete;

namespace BLL.Abstract
{
	public interface IBlogService : IGenericService<Blog>
	{
        Task<List<Blog>> GetListWithCategoryAsync();
		Task<List<Blog>> GetBlogsByWriterAsync(int id);
        Task<List<Blog>> GetListWithCategoryAsync(int id);
    }
}
