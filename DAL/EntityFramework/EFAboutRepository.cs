using DAL.Abstract;
using DAL.Context;
using DAL.Repositories;
using Entities.Concrete;

namespace DAL.EntityFramework
{
    public class EFAboutRepository : GenericRepository<About>, IAboutDAL
    {
        public EFAboutRepository(MyContext context) : base(context)
        {

        }
    }
}
