using Microsoft.EntityFrameworkCore;
using Sana.Backend.Domain.Common;
using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;
using Sana.Backend.Domain.Port.Base;
using Sana.Backend.Infrastructure.Repositories.Base;
using System.Linq.Expressions;

namespace Sana.Backend.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IRepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IMainContext mainContext) : base(mainContext)
        {

        }
        public override async Task<Order> GetById(Guid id)
            => await entity
               .Include(p => p.Items)
               .Include(c => c.Customer)
               .Where(c => c.Id == id)
               .FirstOrDefaultAsync() ?? new();

        public override async Task<List<Order>> ToList() => await entity.Include(p => p.Items).Include(c => c.Customer).ToListAsync();

        public override async Task<List<Order>> ToListBy(Expression<Func<Order, bool>> expression)
            => await entity.Where(expression).Include(p => p.Items).Include(c => c.Customer).ToListAsync();

        public override async Task<Paginate<Order>> Paginate(int page, int lenght)
            => await Paginator<Order>.Paginate(entity.Include(p => p.Items).Include(c => c.Customer).AsQueryable(), page, lenght);

        public async Task<Order> GetOrderByDocument(string document)
            => await entity.Where(o => o.Document == document).Include(p => p.Items).Include(c => c.Customer).FirstOrDefaultAsync()??new();

    }
}
