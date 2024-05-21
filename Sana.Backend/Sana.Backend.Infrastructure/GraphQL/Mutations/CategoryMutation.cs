using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;

namespace Sana.Backend.Infrastructure.GraphQL.Mutations
{
    public partial class Mutation
    {
        public async Task<Category> CreateCategory(
                [Service] ICategoryRepository categoryRepository,
                string code,
                string description
            )
        {
            Category category = new(code, description);
            return await categoryRepository.Create(category);
        }

        public async Task<Category> UpdateCategory(
            [Service] ICategoryRepository categoryRepository,
            Guid id,
            string code,
            string description
            )
        {
            Category category = new(code, description, id);

            return await categoryRepository.Update(category);
        }

        public async Task<bool> DeleteCategory(
            [Service] ICategoryRepository categoryRepository,
            Guid id)
        {
            return await categoryRepository.Delete(id);
         }
    }
}
