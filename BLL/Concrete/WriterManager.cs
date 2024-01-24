
using BLL.Abstract;
using DAL.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace BLL.Concrete
{
	public class WriterManager : IWriterService
	{
		private readonly IWriterDAL _writerDAL;
        public WriterManager(IWriterDAL writerDAL)
        {
            _writerDAL = writerDAL;
        }
        public async Task AddAsync(Writer writer) => await _writerDAL.AddAsync(writer);

		public async Task DeleteAsync(Writer writer) => await _writerDAL.DeleteAsync(writer);

		public async Task<IEnumerable<Writer>> GetAllAsync() => await _writerDAL.GetAllAsync();

		public async Task<IEnumerable<Writer>> GetAllAsync(Expression<Func<Writer, bool>> filter) => await _writerDAL.GetAllAsync(filter);

		public async Task<Writer> GetByIdAsync(int id) => await _writerDAL.GetByIdAsync(id);

        public async Task<List<Writer>> GetWriterByIdAsync(int id) => await _writerDAL.GetWriterByIdAsync(id);

        public async Task UpdateAsync(Writer writer) => await _writerDAL.UpdateAsync(writer);
	}
}
