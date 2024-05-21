using Sana.Backend.Domain.Common;
using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;


namespace Sana.Backend.Infrastructure.GraphQL.Queries
{
    public partial class Query
    {

        public async Task<IEnumerable<OrderPpal>> GetOrders([Service] IOrderRepository repository)
            => await repository.ToList();
        public async Task<OrderPpal> GetOrderById([Service] IOrderRepository repository, Guid Id)
             => await repository.GetById(Id);

        public async Task<OrderPpal> GetOrderByDocument([Service] IOrderRepository repository, string document)
            => await repository.GetOrderByDocument(document);

        public async Task<Paginate<OrderPpal>> PaginateOrderBasic([Service] IOrderRepository repository, int page, int lenght)
        => await repository.Paginate(page, lenght);



    }

}
