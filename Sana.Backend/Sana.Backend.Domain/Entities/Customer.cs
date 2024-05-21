using Sana.Backend.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Sana.Backend.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            
        }
        public Customer(string document, 
                    string name, 
                    string address,
                    string city,
                    string email, 
                    string telephone,
                    string cellphone,
                    Guid? Id=null)
        {
             Id = Id ?? Guid.NewGuid();
            Document = document;
            Name = name;
            Address = address;
            City = city;
            Email = email;
            Telephone = telephone;
            Cellphone = cellphone;

        }
        [JsonPropertyName("document")]
        [Required]
        [Column(nameof(Customer.Document), TypeName = "nvarchar(20)")]
        public string Document { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        [Column(nameof(Customer.Name), TypeName = "nvarchar(100)")]
        [Required]

        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("address")]
        [Column(nameof(Customer.Address), TypeName = "nvarchar(100)")]
        [Required]
        public string Address { get; set; } = string.Empty;
        [JsonPropertyName("city")]
        [Column(nameof(Customer.City), TypeName = "nvarchar(100)")]
        [Required]
        public string City { get; set; } = string.Empty;
        [JsonPropertyName("email")]
        [Column(nameof(Customer.Email), TypeName = "nvarchar(100)")]
        [Required]
        public string Email { get; set; } = string.Empty;
        [JsonPropertyName("telephone")]
        [Column(nameof(Customer.Telephone), TypeName = "nvarchar(20)")]
        [Required]
        public string Telephone { get; set; } = string.Empty;
        [JsonPropertyName("cellphone")]
        [Column(nameof(Customer.Cellphone), TypeName = "nvarchar(20)")]
        [Required]
        public string Cellphone { get; set; } = string.Empty;
        [JsonPropertyName("Orders")]
        public ICollection<OrderPpal>? Orders { get; set; }
    }
}
