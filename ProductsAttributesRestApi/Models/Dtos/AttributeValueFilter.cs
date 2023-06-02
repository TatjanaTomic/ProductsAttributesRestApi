namespace ProductsAttributesRestApi.Models.Dtos;

public class AttributeValueFilter
{
    public int AttributeId { get; set; }
    public string AttributeName { get; set; } = null!;
    public string Value { get; set; } = null!;
}
