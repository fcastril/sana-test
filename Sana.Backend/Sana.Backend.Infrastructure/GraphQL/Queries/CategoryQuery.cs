using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;


namespace Sana.Backend.Infrastructure.GraphQL.Queries
{
    public partial class Query
    {

        public async Task<IEnumerable<Category>> GetCategories([Service] ICategoryRepository repository)
            => await repository.ToList();
        public async Task<Category> GetCategoryById([Service] ICategoryRepository repository, Guid Id)
             => await repository.GetById(Id);
    }

}
