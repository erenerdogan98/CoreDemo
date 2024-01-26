using DAL.Context;
using DAL.Repositories;
using Entities;

namespace DAL.EntityFramework
{
    public class EFMessageRepository : GenericRepository<Message>
    {
        public EFMessageRepository(MyContext context) : base(context)
        {
            
        }
    }
}
