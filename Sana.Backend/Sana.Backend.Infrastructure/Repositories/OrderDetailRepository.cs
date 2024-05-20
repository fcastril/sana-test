using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;
using Sana.Backend.Domain.Port.Base;
using Sana.Backend.Infrastructure.Repositories.Base;

namespace Sana.Backend.Infrastructure.Repositories
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IRepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IMainContext mainContext) : base(mainContext)
        {

        }
    }
}
