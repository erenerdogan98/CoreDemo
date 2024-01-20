using DAL.Abstract;
using DAL.Context;
using DAL.Repositories;
using Entities.Concrete;

namespace DAL.EntityFramework
{
    public class EFBlogRepository : GenericRepository<Blog>, IBlogDAL
    {
        public EFBlogRepository(MyContext context) : base(context)
        {

        }
    }
}
