using Sana.Backend.Domain.Common;
using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;


namespace Sana.Backend.Infrastructure.GraphQL.Queries
{
    public partial class Query
    {

        public async Task<IEnumerable<Customer>> GetCustomers([Service] ICustomerRepository repository)
            => await repository.ToList();
        public async Task<Customer> GetCustomerById([Service] ICustomerRepository repository, Guid Id)
             => await repository.GetById(Id);

        public async Task<Paginate<Customer>> PaginateCustomerBasic([Service] ICustomerRepository repository, int page, int lenght)
         => await repository.Paginate(page, lenght);

        public async Task<Customer> GetCustomerByDocument([Service] ICustomerRepository repository, string Document)
             => await repository.GetCustomerByDocument(Document);

    }

}
