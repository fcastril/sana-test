using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;

namespace Sana.Backend.Infrastructure.GraphQL.Mutations
{
    public partial class Mutation
    {
        public async Task<OrderPpal> CreateOrder(
                [Service] IOrderRepository orderRepository,
                [Service] ICustomerRepository customerRepository,
                string document,
                DateTime date,
                Guid customerId
            )
        {
            Customer? customer = await customerRepository.GetById(customerId);
            if (customer == null) throw new Exception("Customer not found");

            OrderPpal Order = new(document, date, customer);
            return await orderRepository.Create(Order);
        }

        public async Task<OrderPpal> UpdateOrder(
                [Service] IOrderRepository orderRepository,
                [Service] ICustomerRepository customerRepository,
                Guid id, 
                string document,
                DateTime date,
                Guid customerId
                    )
        {

            Customer? customer = await customerRepository.GetById(customerId);
            if (customer == null) throw new Exception("Customer not found");

            OrderPpal? Order = await orderRepository.GetById(id);
            if (customer == null) throw new Exception("Order not found");

            
            Order!.Document = document;
            Order.Date = date;
            Order.CustomerId = customerId;

            return await orderRepository.Update(Order);
        }

        public async Task<bool> DeleteOrder(
            [Service] IOrderRepository OrderRepository,
            Guid id)
        {
            return await OrderRepository.Delete(id);
         }
    }
}
