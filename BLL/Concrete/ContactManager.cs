using BLL.Abstract;
using DAL.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace BLL.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDAL _contactDAL;
        public async Task AddAsync(Contact contact) => await _contactDAL.AddAsync(contact);

        public async Task DeleteAsync(Contact contact) => await _contactDAL.DeleteAsync(contact);

        public async Task<IEnumerable<Contact>> GetAllAsync() => await _contactDAL.GetAllAsync();

        public async Task<IEnumerable<Contact>> GetAllAsync(Expression<Func<Contact, bool>> filter) => await _contactDAL.GetAllAsync(filter);

        public async Task<Contact> GetByIdAsync(int id) => await _contactDAL.GetByIdAsync(id);

        public async Task UpdateAsync(Contact contact) => await _contactDAL.UpdateAsync(contact);
    }
}
