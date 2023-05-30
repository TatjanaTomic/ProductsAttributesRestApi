namespace ProductsAttributesRestApi.Models.Dtos;

public class ProductFilterRequest
{
    public int? Id { get; set; } = null;
    public string? Name { get; set; } = null;
    public string? Code { get; set; } = null;
    public string? Manufacturer { get; set; } = null;
    public string? UnitOfMeasurement { get; set; } = null;
}
