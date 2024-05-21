using Sana.Backend.Domain.Common;
using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;


namespace Sana.Backend.Infrastructure.GraphQL.Queries
{
    public partial class Query
    {

        public async Task<IEnumerable<OrderDetail>> GetOrdersDetails([Service] IOrderDetailRepository repository)
            => await repository.ToList();
        public async Task<OrderDetail> GetOrderDetailById([Service] IOrderDetailRepository repository, Guid Id)
             => await repository.GetById(Id);
        public async Task<OrderDetail> GetOrderDetailByOrderId([Service] IOrderDetailRepository repository, Guid Id)
            => await repository.GetByOrderId(Id);

        public async Task<Paginate<OrderDetail>> PaginateOrderBasic([Service] IOrderDetailRepository repository, int page, int lenght)
        => await repository.Paginate(page, lenght);



    }

}
