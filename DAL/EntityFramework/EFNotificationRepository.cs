using DAL.Abstract;
using DAL.Context;
using DAL.Repositories;
using Entities.Concrete;

namespace DAL.EntityFramework
{
    public class EFNotificationRepository : GenericRepository<Notification>, INotificationDAL
    {
        public EFNotificationRepository(MyContext context) : base(context)
        {
            
        }
    }
}
