namespace ProductsAttributesRestApi.Models.Dtos;

public class AttributeResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Units { get; set; }
}
