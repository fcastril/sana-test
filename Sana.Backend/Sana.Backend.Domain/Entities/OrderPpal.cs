using Sana.Backend.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sana.Backend.Domain.Entities
{
    public class OrderPpal : BaseEntity
    {
        public OrderPpal()
        {

        }
        public OrderPpal(
                string document,
                DateTime date,
                Customer customer,
                ICollection<OrderDetail>? items = null,
                Guid? id = null
            )
        {
            Id = id ?? Guid.NewGuid();
            Document = document;
            Date = date;
            Customer = customer;
            CustomerId = customer.Id;
            Items = items;
        }
        [JsonPropertyName("document")]
        [Required]

        public string Document { get; set; } = string.Empty;
        [JsonPropertyName("date")]
        [Required]

        public DateTime Date { get; set; }
        [JsonPropertyName("customerId")]
        [Required]

        public Guid? CustomerId { get; set; }
        [JsonPropertyName("Customer")]
        public Customer? Customer { get; set; }
        [JsonPropertyName("Items")]
        public ICollection<OrderDetail>? Items { get; set; }
    }

    public class OrderDetail : BaseEntity
    {
        public OrderDetail()
        {

        }
        public OrderDetail(
                OrderPpal order,
                Product product,
                int quantity,
                 decimal price,
                 Guid? Id = null
            )
        {
            Id = Id ?? Guid.NewGuid();
            Order = order;
            OrderId = order.Id;
            ProductId = product.Id;
            Product = product;
            Quantity = quantity;
            Price = price;
        }
        [JsonPropertyName("orderId")]
        [Required]

        public Guid? OrderId { get; set; }
        [JsonPropertyName("order")]
        public OrderPpal? Order { get; set; }

        [JsonPropertyName("productId")]
        [Required]

        public Guid? ProductId { get; set; }
        [JsonPropertyName("product")]
        public Product? Product { get; set; }
        [JsonPropertyName("quantity")]
        [Required]
        public int Quantity { get; set; }

        [JsonPropertyName("price")]
        [Required]

        public decimal Price { get; set; }
    }
}
