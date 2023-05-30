namespace ProductsAttributesRestApi.Models.Dtos;

public class ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!; 
    public string Code { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string? UnitOfMeasurement { get; set; }

}
