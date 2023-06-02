namespace ProductsAttributesRestApi.Models.Dtos;

public class ProductFilterRequest
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Manufacturer { get; set; }
    public string? UnitOfMeasurement { get; set; }
}
