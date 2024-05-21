using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;

namespace Sana.Backend.Infrastructure.GraphQL.Mutations
{
    public partial class Mutation
    {
        public async Task<Product> CreateProduct(
                [Service] IProductRepository ProductRepository,
                [Service] ICategoryRepository categoryRepository,
                string code,
                string name,
                string urlImage,
                decimal price, 
                int stock,
                Guid categoryId
            )
        {
            Category category = await categoryRepository.GetById( categoryId );
            if (category == null)
                   throw   new Exception("Error: CategoryId not found");

            Product Product = new(code, name, urlImage, price, stock, category);
            return await ProductRepository.Create(Product);
        }

        public async Task<Product> UpdateProduct(
                        [Service] IProductRepository ProductRepository,
                        [Service] ICategoryRepository categoryRepository,
                        Guid id,
                        string code,
                        string name,
                        string urlImage,
                        decimal price,
                        int stock,
                        Guid categoryId
                    )
        {
            Category category = await categoryRepository.GetById(categoryId);
            if (category == null)
                throw new Exception("Error: CategoryId not found");

            Product Product = new(code, name, urlImage, price, stock, category, id);
            return await ProductRepository.Update(Product);
        }

        public async Task<bool> DeleteProduct(
            [Service] IProductRepository ProductRepository,
            Guid id)
        {
            return await ProductRepository.Delete(id);
         }
    }
}
