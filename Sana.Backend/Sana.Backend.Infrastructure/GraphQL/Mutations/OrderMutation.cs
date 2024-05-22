using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;

namespace Sana.Backend.Infrastructure.GraphQL.Mutations
{
    public partial class Mutation
    {
        public async Task<OrderPpal> CreateOrder(
                [Service] IOrderRepository OrderRepository,
                [Service] ICustomerRepository customerRepository,
                string document,
                DateTime date,
                Guid customerId
            )
        {
            Customer? customer = await customerRepository.GetById(customerId);
            if (customer == null) throw new Exception("Customer not found");

            OrderPpal Order = new(document, date, customer);
            return await OrderRepository.Create(Order);
        }

        public async Task<OrderPpal> UpdateOrder(
                [Service] IOrderRepository OrderRepository,
                [Service] ICustomerRepository customerRepository,
                Guid Id, 
                string document,
                DateTime date,
                Guid customerId
                    )
        {

            Customer? customer = await customerRepository.GetById(customerId);
            if (customer == null) throw new Exception("Customer not found");

            OrderPpal Order = new(document, date, customer);
            return await OrderRepository.Update(Order);
        }

        public async Task<bool> DeleteOrder(
            [Service] IOrderRepository OrderRepository,
            Guid id)
        {
            return await OrderRepository.Delete(id);
         }
    }
}
