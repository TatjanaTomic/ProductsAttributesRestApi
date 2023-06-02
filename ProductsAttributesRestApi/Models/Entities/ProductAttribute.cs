using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ProductsAttributesRestApi.Models.Entities;

public class ProductAttribute
{
    public int ProductId { get; set; }
    [JsonIgnore]
    public Product Product { get; set; } = null!;
    public int AttributeId { get; set; }
    public Attribute Attribute { get; set; } = null!;
    public string Value { get; set; } = null!;
}
