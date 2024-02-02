using Entities.Concrete;

namespace DAL.Abstract
{
    public interface ICommentDAL : IGenericDAL<Comment>
    {
        Task<List<Comment>> GetListWithBlogAsync();
    }
}
