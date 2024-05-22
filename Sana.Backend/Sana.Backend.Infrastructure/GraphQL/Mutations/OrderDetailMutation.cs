using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;

namespace Sana.Backend.Infrastructure.GraphQL.Mutations
{
    public partial class Mutation
    {
        public async Task<OrderDetail> CreateOrderDetail(
                [Service] IOrderDetailRepository OrderDetailRepository,
                [Service] IOrderRepository orderRepository,
                [Service] IProductRepository productRepository,
                Guid orderId,
                Guid productId,
                int quantity,
                decimal price
            )
        {
            OrderPpal? order = await orderRepository.GetById(orderId);
            if (order == null) throw new Exception("Order not found");

            Product? product = await productRepository.GetById(productId);
            if (product == null) throw new Exception("Product not found");

            OrderDetail OrderDetail = new(order, product, quantity, price);
            return await OrderDetailRepository.Create(OrderDetail);
        }

        public async Task<OrderDetail> UpdateOrderDetail(
                    [Service] IOrderDetailRepository OrderDetailRepository,
                [Service] IOrderRepository orderRepository,
                [Service] IProductRepository productRepository,
                Guid id,
                Guid orderId,
                Guid productId,
                int quantity,
                decimal price
            )
        {
            OrderPpal? order = await orderRepository.GetById(orderId);
            if (order == null) throw new Exception("Order not found");

            Product? product = await productRepository.GetById(productId);
            if (product == null) throw new Exception("Product not found");

            OrderDetail OrderDetail = new(order, product, quantity, price, id);
            return await OrderDetailRepository.Update(OrderDetail);
        }

        public async Task<bool> DeleteOrderDetail(
            [Service] IOrderDetailRepository OrderDetailRepository,
            Guid id)
        {
            return await OrderDetailRepository.Delete(id);
         }
    }
}
