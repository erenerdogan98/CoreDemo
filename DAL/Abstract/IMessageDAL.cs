using Entities.Concrete;

namespace DAL.Abstract
{
    public interface IMessageDAL : IGenericDAL<Message>
    {
        Task<List<Message>> GetInBoxListByWriter(string reciever);
    }
}
