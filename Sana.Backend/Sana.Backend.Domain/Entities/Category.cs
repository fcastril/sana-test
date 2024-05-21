using Sana.Backend.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sana.Backend.Domain.Entities
{
    public class Category : BaseEntity
    {
        [JsonPropertyName("code")]
        [Column(nameof(Category.Code), TypeName = "nvarchar(20)")]
        public string Code { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        [Column(nameof(Category.Description), TypeName = "nvarchar(100)")]
        public string Description { get; set; } = String.Empty;
        [JsonPropertyName("products")]
        public ICollection<Product>? Products { get; set;}
    }
}
