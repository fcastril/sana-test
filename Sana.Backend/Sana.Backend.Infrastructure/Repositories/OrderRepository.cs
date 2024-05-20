using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;
using Sana.Backend.Domain.Port.Base;
using Sana.Backend.Infrastructure.Repositories.Base;

namespace Sana.Backend.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IRepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IMainContext mainContext) : base(mainContext)
        {

        }
    }
}
