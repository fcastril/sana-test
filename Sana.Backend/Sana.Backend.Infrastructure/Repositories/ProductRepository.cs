using Microsoft.EntityFrameworkCore;
using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;
using Sana.Backend.Domain.Port.Base;
using Sana.Backend.Infrastructure.Repositories.Base;

namespace Sana.Backend.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IRepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IMainContext mainContext) : base(mainContext)
        {

        }
        public override async Task<Product> GetById(Guid id)
            => await entity
               .Include(p => p.Category)
               .Where(c => c.Id == id)
               .FirstOrDefaultAsync() ?? new();

        public override async Task<List<Product>> ToList() => await entity.Include(p => p.Category).ToListAsync();
    }
}
