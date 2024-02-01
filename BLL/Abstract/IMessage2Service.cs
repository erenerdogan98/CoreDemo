using Entities.Concrete;

namespace BLL.Abstract
{
    public interface IMessage2Service : IGenericService<Message2>
    {
        Task<List<Message2>> GetInBoxListByWriter(int receiverId);
        Task<List<Message2>> GetSendBoxByWriterAsync(int receiverId);   
    }
}
