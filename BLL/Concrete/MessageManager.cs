using BLL.Abstract;
using DAL.Abstract;
using Entities;
using System.Linq.Expressions;

namespace BLL.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDAL _messageDAL;
        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL ?? throw new ArgumentNullException(nameof(messageDAL));
        }
        public async Task AddAsync(Message message) => await _messageDAL.AddAsync(message); 

        public async Task DeleteAsync(Message message) => await _messageDAL.DeleteAsync(message);

        public async Task<IEnumerable<Message>> GetAllAsync() => await _messageDAL.GetAllAsync();

        public async Task<IEnumerable<Message>> GetAllAsync(Expression<Func<Message, bool>> filter) => await _messageDAL.GetAllAsync(filter);

        public async Task<Message> GetByIdAsync(int id) => await _messageDAL.GetByIdAsync(id);

        public async Task UpdateAsync(Message message) => await _messageDAL.UpdateAsync(message);
    }
}
