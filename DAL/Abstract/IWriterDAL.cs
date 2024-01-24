using Entities.Concrete;

namespace DAL.Abstract
{
    public interface IWriterDAL : IGenericDAL<Writer>
    {
        Task<List<Writer>> GetWriterByIdAsync(int id); // for admin panels , will use 
    }
}
