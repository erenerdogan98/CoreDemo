﻿using Entities;

namespace BLL.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        Task<List<Message>> GetInBoxListByWriter(string receiver);
    }
}