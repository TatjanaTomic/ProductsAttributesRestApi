using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAttributesRestApi.Models.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Attribute> Attributes { get; set; } = new();
    [NotMapped]
    public List<ProductAttribute> ProductAttributes { get; set; } = new();
}
