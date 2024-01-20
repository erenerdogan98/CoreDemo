using DAL.Abstract;
using DAL.Context;
using Entities.Concrete;

namespace DAL.Repositories
{
    public class AboutRepository : GenericRepository<About> , IAboutDAL
    {
        public AboutRepository(MyContext context) : base(context)
        {
            
        }
    }
}
