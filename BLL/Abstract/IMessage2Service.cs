using Entities.Concrete;

namespace BLL.Abstract
{
    public interface IMessage2Service : IGenericService<Message2>
    {
        Task<IEnumerable<Message2>> GetInBoxListByWriter(int receiverId);
    }
}
