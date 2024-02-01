using Entities.Concrete;

namespace DAL.Abstract
{
    public interface IMessage2DAL : IGenericDAL<Message2>
    {
        Task<List<Message2>> GetListWithMessageByWriterAsync(int id);
        Task<List<Message2>> GetSendBoxByWriterAsync(int id);
    }
}
