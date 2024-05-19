using Sana.Backend.Domain.Common;
using System.Text.Json.Serialization;

namespace Sana.Backend.Domain.Entities
{
    public class Order : BaseEntity
    {
        [JsonPropertyName("document")]
        public string Document { get; set; } = string.Empty;
        [JsonPropertyName("date")]
        public DateTime date { get; set; }
        [JsonPropertyName("customerId")]
        public Guid? CustomerId { get; set; }
        [JsonPropertyName("Customer")]
        public virtual Customer? CustomerNavigation { get; set; }
        [JsonPropertyName("Items")]
        public virtual List<OrderDetail>? Items { get; set; }
    }

    public class OrderDetail : BaseEntity
    {
        [JsonPropertyName("orderId")]
        public Guid? OrderId { get; set; }
        [JsonPropertyName("order")]
        public virtual Order? OrderNavigation { get; set; }

        [JsonPropertyName("productId")]
        public Guid? ProductId { get; set; }
        [JsonPropertyName("product")]
        public virtual Product? ProductNavigation { get; set; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
