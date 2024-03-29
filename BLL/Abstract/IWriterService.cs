﻿using Entities.Concrete;

namespace BLL.Abstract
{
	public interface IWriterService : IGenericService<Writer>
	{
        Task<List<Writer>> GetWriterByIdAsync(int id);
    }
}
