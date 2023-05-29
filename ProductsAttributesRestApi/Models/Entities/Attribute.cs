using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAttributesRestApi.Models.Entities;

public class Attribute
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Units { get; set; }
    public List<Product> Products { get; set; } = new();
    [NotMapped]
    public List<ProductAttribute> ProductAttributes { get; set; } = new();
}
