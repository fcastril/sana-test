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
    }
}
