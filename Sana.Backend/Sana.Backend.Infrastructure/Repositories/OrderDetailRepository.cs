using Microsoft.EntityFrameworkCore;
using Sana.Backend.Domain.Common;
using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;
using Sana.Backend.Domain.Port.Base;
using Sana.Backend.Infrastructure.Repositories.Base;
using System.Linq.Expressions;

namespace Sana.Backend.Infrastructure.Repositories
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IRepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IMainContext mainContext) : base(mainContext)
        {

        }
        public override async Task<OrderDetail> GetById(Guid id)
           => await entity
              .Include(p => p.Order)
              .Include(c => c.Product)
              .Where(c => c.Id == id)
              .FirstOrDefaultAsync() ?? new();

        public override async Task<List<OrderDetail>> ToList() => await entity.Include(p => p.Order).Include(c => c.Product).ToListAsync();

        public override async Task<List<OrderDetail>> ToListBy(Expression<Func<OrderDetail, bool>> expression)
            => await entity.Where(expression).Include(p => p.Order).Include(c => c.Product).ToListAsync();

        public override async Task<Paginate<OrderDetail>> Paginate(int page, int lenght)
            => await Paginator<OrderDetail>.Paginate(entity.Include(p => p.Order).Include(c => c.Product).AsQueryable(), page, lenght);
        public async Task<OrderDetail> GetByOrderId(Guid id)
            => await entity.Where(od => od.OrderId == id).Include(p => p.Order).Include(c => c.Product).FirstOrDefaultAsync() ?? new();

    }
}
