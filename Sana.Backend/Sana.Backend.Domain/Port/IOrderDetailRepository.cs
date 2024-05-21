using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port.Base;

namespace Sana.Backend.Domain.Port
{                                                    
    public interface IOrderDetailRepository : IRepositoryBase<OrderDetail>
    {
        Task<OrderDetail> GetByOrderId(Guid id);
    }
}
