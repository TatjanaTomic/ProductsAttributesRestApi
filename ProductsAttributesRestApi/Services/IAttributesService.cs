using ProductsAttributesRestApi.Models.Dtos;

namespace ProductsAttributesRestApi.Services;

public interface IAttributesService
{
    Task<List<AttributeResponse>> GetAllAttributes();
    Task<AttributeResponse> GetAttributeById(int id);
    Task<AttributeResponse> AddAttribute(AttributeRequest attributeRequest);
    Task<AttributeResponse> UpdateAttribute(int id, AttributeRequest attributeRequest);
    Task<List<AttributeResponse>?> DeleteAttribute(int id);

}
