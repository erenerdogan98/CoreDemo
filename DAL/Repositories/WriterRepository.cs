using DAL.Abstract;
using DAL.Context;
using Entities.Concrete;


namespace DAL.Repositories
{
    public class WriterRepository : GenericRepository<Writer> , IWriterDAL
    {
        public WriterRepository(MyContext context) : base(context)
        {
            
        }
    }
}
