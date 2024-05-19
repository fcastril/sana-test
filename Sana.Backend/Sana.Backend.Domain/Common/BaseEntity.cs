using System.Text.Json.Serialization;

namespace Sana.Backend.Domain.Common
{
    public class BaseEntity
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
