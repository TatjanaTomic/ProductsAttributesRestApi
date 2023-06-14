using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAttributesRestApi.Models.Entities;

[PrimaryKey(nameof(ProductId), nameof(AttributeId))]
public class ProductAttribute
{
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    [ForeignKey("Attribute")]
    public int AttributeId { get; set; }
    public Attribute Attribute { get; set; } = null!;
    public string Value { get; set; } = null!;
}
