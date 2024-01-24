using BLL.Abstract;
using DAL.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace BLL.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDAL _notificationDAL;
        public NotificationManager(INotificationDAL notificationDAL)
        {
            _notificationDAL = notificationDAL ?? throw new ArgumentNullException(nameof(notificationDAL));
        }
        public async Task AddAsync(Notification notification) => await _notificationDAL.AddAsync(notification);

        public async Task DeleteAsync(Notification notification) => await _notificationDAL.DeleteAsync(notification);

        public async Task<IEnumerable<Notification>> GetAllAsync() => await _notificationDAL.GetAllAsync();

        public async Task<IEnumerable<Notification>> GetAllAsync(Expression<Func<Notification, bool>> filter) => await _notificationDAL.GetAllAsync(filter);

        public async Task<Notification> GetByIdAsync(int id) => await _notificationDAL.GetByIdAsync(id);

        public async Task UpdateAsync(Notification notification) => await _notificationDAL.UpdateAsync(notification);
    }
}
