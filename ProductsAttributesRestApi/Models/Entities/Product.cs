using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAttributesRestApi.Models.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string? UnitOfMeasurement { get; set; } 
    public List<ProductAttribute> ProductAttributes { get; set; } = new();
}
