using Entities;

namespace DAL.Abstract
{
    public interface IMessageDAL : IGenericDAL<Message>
    {
        Task<List<Message>> GetListByWriter(int id);
    }
}
