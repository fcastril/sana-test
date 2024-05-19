using Sana.Backend.Domain.Common;
using System.Text.Json.Serialization;

namespace Sana.Backend.Domain.Entities
{
    public class Category : BaseEntity
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;
        [JsonPropertyName("Description")]
        public string Description { get; set; } = String.Empty;
    }
}
