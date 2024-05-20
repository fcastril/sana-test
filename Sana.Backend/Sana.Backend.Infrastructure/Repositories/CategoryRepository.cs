using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;
using Sana.Backend.Domain.Port.Base;
using Sana.Backend.Infrastructure.Repositories.Base;

namespace Sana.Backend.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, IRepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IMainContext mainContext) : base(mainContext)
        {

        }
    }
}
