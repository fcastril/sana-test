using Sana.Backend.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Sana.Backend.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            
        }

        public Product(string code, string name, string urlImage, decimal price, int stock, Category category, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Code = code;
            Name = name;
            UrlImage = urlImage;
            Price = price;
            Stock = stock;
            CategoryId = category.Id;
            Category = category;
        }
        [JsonPropertyName("code")]
        [Required]
        public string Code { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        [Required]

        public string Name { get; set; } = string.Empty;


        [JsonPropertyName("UrlImage")]
        [Required]

        public string UrlImage { get; set; }
        [JsonPropertyName("price")]
        [Required]

        public decimal Price { get; set; }
        [JsonPropertyName("stock")]
        [Required]

        public int Stock { get; set; }
        [JsonPropertyName("CategoryId")]
        [Required]

        public Guid CategoryId { get; set; }
        [JsonPropertyName("category")]
        public Category? Category { get; set; }
    }
}
