using Sana.Backend.Domain.Common;
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

        public async Task<Paginate<Category>> PaginateCategoryBasic([Service] ICategoryRepository repository, int page, int len)
                => await repository.Paginate(page, len);

        public async Task<Paginate<Category>> PaginateCategory([Service] ICategoryRepository repository, Paginate<Category> paginate)
                => await repository.Paginate(paginate);
    }

}
