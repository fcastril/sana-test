using Sana.Backend.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sana.Backend.Domain.Entities
{
    public class Order : BaseEntity
    {
        [JsonPropertyName("document")]
        [Required]

        public string Document { get; set; } = string.Empty;
        [JsonPropertyName("date")]
        [Required]

        public DateTime date { get; set; }
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
        [JsonPropertyName("orderId")]
        [Required]

        public Guid? OrderId { get; set; }
        [JsonPropertyName("order")]
        public Order? Order { get; set; }

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
