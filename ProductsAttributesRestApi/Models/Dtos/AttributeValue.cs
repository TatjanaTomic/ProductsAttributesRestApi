namespace ProductsAttributesRestApi.Models.Dtos;

public class AttributeValue
{
    public Attribute Attribute { get; set; } = null!;
    public string Value { get; set; } = null!;
}
