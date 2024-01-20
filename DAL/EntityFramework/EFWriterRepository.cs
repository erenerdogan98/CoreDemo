using DAL.Abstract;
using DAL.Context;
using DAL.Repositories;
using Entities.Concrete;


namespace DAL.EntityFramework
{
    public class EFWriterRepository : GenericRepository<Writer>, IWriterDAL
    {
        public EFWriterRepository(MyContext context) : base(context)
        {

        }
    }
}
