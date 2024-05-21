using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;

namespace Sana.Backend.Infrastructure.GraphQL.Mutations
{
    public partial class Mutation
    {
        public async Task<Customer> CreateCustomer(
                [Service] ICustomerRepository CustomerRepository,
                string document,
                string name,
                string address,
                string city,
                string email,
                string telephone,
                string cellphone
            )
        {

            Customer Customer = new(document, name, address, city, email, telephone, cellphone);
            return await CustomerRepository.Create(Customer);
        }

        public async Task<Customer> UpdateCustomer(
                        [Service] ICustomerRepository CustomerRepository,
                        [Service] ICategoryRepository categoryRepository,
                        Guid id,
                        string document,
                        string name,
                        string address,
                        string city,
                        string email,
                        string telephone,
                        string cellphone
                    )
        {

            Customer Customer = new(document, name, address, city, email, telephone, cellphone, id);
            return await CustomerRepository.Update(Customer);
        }

        public async Task<bool> DeleteCustomer(
            [Service] ICustomerRepository CustomerRepository,
            Guid id)
        {
            return await CustomerRepository.Delete(id);
         }
    }
}
