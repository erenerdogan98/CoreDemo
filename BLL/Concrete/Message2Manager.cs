using BLL.Abstract;
using DAL.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace BLL.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        private readonly IMessage2DAL _message2DAL;
        public Message2Manager(IMessage2DAL message2DAL)
        {
            this._message2DAL = message2DAL ?? throw new ArgumentNullException(nameof(message2DAL));
        }
        public async Task AddAsync(Message2 message) => await _message2DAL.AddAsync(message);

        public async Task DeleteAsync(Message2 message) => await _message2DAL.DeleteAsync(message);

        public async Task<IEnumerable<Message2>> GetAllAsync() => await _message2DAL.GetAllAsync();

        public async Task<IEnumerable<Message2>> GetAllAsync(Expression<Func<Message2, bool>> filter) => await _message2DAL.GetAllAsync(filter);

        public async Task<Message2> GetByIdAsync(int id) => await _message2DAL.GetByIdAsync(id);

        public async Task<List<Message2>> GetInBoxListByWriter(int receiverId) => await _message2DAL.GetListWithMessageByWriterAsync(receiverId);

        public async Task<List<Message2>> GetSendBoxByWriterAsync(int receiverId) => await _message2DAL.GetSendBoxByWriterAsync(receiverId);

        public async Task UpdateAsync(Message2 message) => await _message2DAL.UpdateAsync(message);
    }
}
