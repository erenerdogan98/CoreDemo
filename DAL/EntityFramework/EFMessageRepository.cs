using DAL.Abstract;
using DAL.Context;
using DAL.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.EntityFramework
{
    public class EFMessageRepository : GenericRepository<Message> , IMessageDAL
    {
        private readonly MyContext _context;
        public EFMessageRepository(MyContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Message>> GetInBoxListByWriter(string receiver)
        {
            return await _context.Set<Message>()
                .Where(x => x.Receiver == receiver) // Filtreleme işlemi Where metodu ile gerçekleştirin
                .ToListAsync();
        }

    }
}
