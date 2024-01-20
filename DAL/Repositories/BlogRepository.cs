using DAL.Abstract;
using DAL.Context;
using Entities.Concrete;

namespace DAL.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogDAL
    {
        public BlogRepository(MyContext context) : base(context)
        {
            
        }
    }
}
