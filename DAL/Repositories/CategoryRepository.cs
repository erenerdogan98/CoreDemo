using DAL.Abstract;
using DAL.Context;
using Entities.Concrete;

namespace DAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category> , ICategoryDAL
    {
        public CategoryRepository(MyContext context) : base(context)
        {
            
        }
    }
}
