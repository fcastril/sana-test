using Sana.Backend.Domain.Common;
using System.Text.Json.Serialization;

namespace Sana.Backend.Domain.Entities
{
    public class Product : BaseEntity
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("stock")]
        public int Stock { get; set; }
        [JsonPropertyName("categoryId")]
        public Guid CategoryId { get; set; }
        [JsonPropertyName("category")]
        public virtual Category? CategoryNavigation { get; set; }
    }
}
