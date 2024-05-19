using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sana.Backend.Domain.Common
{
    public class BaseEntity
    {
        [JsonPropertyName("id")]
        [Key]
        public Guid Id { get; set; }
    }
}
