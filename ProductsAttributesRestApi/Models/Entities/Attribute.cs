using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProductsAttributesRestApi.Models.Entities;

public class Attribute
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Units { get; set; }
    [JsonIgnore]
    public List<Product> Products { get; set; } = new();
    [JsonIgnore]
    [NotMapped]
    public List<ProductAttribute> ProductAttributes { get; set; } = new();
}
