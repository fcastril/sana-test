using Sana.Backend.Domain.Common;
using System.Text.Json.Serialization;

namespace Sana.Backend.Domain.Entities
{
    public class Customer : BaseEntity
    {
        [JsonPropertyName("document")]
        public string Document { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;
        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
        [JsonPropertyName("telephone")]
        public string Telephone { get; set; } = string.Empty;
        [JsonPropertyName("cellphone")]
        public string Cellphone { get; set; } = string.Empty;
    }
}
