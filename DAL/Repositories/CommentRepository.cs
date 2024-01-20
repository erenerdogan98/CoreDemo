using DAL.Abstract;
using DAL.Context;
using Entities.Concrete;

namespace DAL.Repositories
{
    public class CommentRepository : GenericRepository<Comment> , ICommentDAL
    {
        public CommentRepository(MyContext context) : base(context)
        {
            
        }
    }
}
