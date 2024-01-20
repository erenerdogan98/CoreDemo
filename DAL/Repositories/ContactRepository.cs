using DAL.Abstract;
using DAL.Context;
using Entities.Concrete;

namespace DAL.Repositories
{
    public class ContactRepository : GenericRepository<Contact> , IContactDAL
    {
        public ContactRepository(MyContext context) : base(context)
        {
            
        }
    }
}
