using DAL.Abstract;
using DAL.Context;
using DAL.Repositories;
using Entities.Concrete;

namespace DAL.EntityFramework
{
    public class EFNewsLetterRepository : GenericRepository<NewsLetter>, INewsLetterDAL
    {
        public EFNewsLetterRepository(MyContext context) : base(context)
        {

        }
    }
}
