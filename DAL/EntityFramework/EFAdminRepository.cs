using DAL.Abstract;
using DAL.Context;
using DAL.Repositories;
using Entities.Concrete;

namespace DAL.EntityFramework
{
    public class EFAdminRepository : GenericRepository<Admin>, IAdminDAL
    {
        public EFAdminRepository(MyContext context) : base(context)
        {
            
        }
    }
}
