using DAL.Abstract;
using DAL.Context;
using DAL.Repositories;
using Entities.Concrete;

namespace DAL.EntityFramework
{
    public class EFMessage2Repository : GenericRepository<Message2> , IMessage2DAL
    {
        public EFMessage2Repository(MyContext context) : base(context)
        {
            
        }
    }
}
