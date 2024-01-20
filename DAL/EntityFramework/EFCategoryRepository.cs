using DAL.Abstract;
using DAL.Context;
using DAL.Repositories;
using Entities.Concrete;

namespace DAL.EntityFramework
{
    public class EFCategoryRepository : GenericRepository<Category>, ICategoryDAL
    {
        public EFCategoryRepository(MyContext context) : base(context)
        {

        }
    }
}
