using DAL.Abstract;
using DAL.Context;
using DAL.Repositories;
using Entities.Concrete;

namespace DAL.EntityFramework
{
    public class EFCommentRepository : GenericRepository<Comment>, ICommentDAL
    {
        public EFCommentRepository(MyContext context) : base(context)
        {

        }
    }
}
