using Microsoft.EntityFrameworkCore;
using Sana.Backend.Domain.Common;
using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;
using Sana.Backend.Domain.Port.Base;
using Sana.Backend.Infrastructure.Repositories.Base;
using System.Linq.Expressions;

namespace Sana.Backend.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, IRepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IMainContext mainContext) : base(mainContext)
        {

        }

        public override async Task<Customer> GetById(Guid id)
            => await entity
               .Include(p => p.Orders)
               .Where(c => c.Id == id)
               .FirstOrDefaultAsync() ?? new();
        public  async Task<Customer> GetCustomerByDocument(string document)
           => await entity
              .Include(p => p.Orders)
              .Where(c => c.Document == document)
              .FirstOrDefaultAsync() ?? new();
        public override async Task<List<Customer>> ToList() => await entity.Include(p => p.Orders).ToListAsync();

        public override async Task<List<Customer>> ToListBy(Expression<Func<Customer, bool>> expression)
            => await entity.Where(expression).Include(p => p.Orders).ToListAsync();

        public override async Task<Paginate<Customer>> Paginate(int page, int lenght)
            => await Paginator<Customer>.Paginate(entity.Include(p => p.Orders).AsQueryable(), page, lenght);

    }
}
