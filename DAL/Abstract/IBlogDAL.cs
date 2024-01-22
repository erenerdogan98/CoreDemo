using Entities.Concrete;

namespace DAL.Abstract
{
    public interface IBlogDAL : IGenericDAL<Blog>
    {
        Task<List<Blog>> GetListWithCategoryAsync();
        Task<List<Blog>> GetBlogsByWriterAsync(int id);
    }
}
