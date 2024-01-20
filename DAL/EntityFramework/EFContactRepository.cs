using DAL.Abstract;
using DAL.Context;
using DAL.Repositories;
using Entities.Concrete;

namespace DAL.EntityFramework
{
    public class EFContactRepository : GenericRepository<Contact>, IContactDAL
    {
        public EFContactRepository(MyContext context) : base(context)
        {

        }
    }
}
