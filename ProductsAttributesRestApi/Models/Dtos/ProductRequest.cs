namespace ProductsAttributesRestApi.Models.Dtos;

public class ProductRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
}
