﻿using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port.Base;

namespace Sana.Backend.Domain.Port
{
    public interface IOrderRepository : IRepositoryBase<OrderPpal>
    {
        Task<OrderPpal> GetOrderByDocument(string document);
    }
}
