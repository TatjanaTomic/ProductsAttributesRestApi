namespace ProductsAttributesRestApi.Repositories;

public interface IAttributesRepository
{
    Task<List<Attribute>> GetAllAttributes();
    Task<Attribute?> GetAttributeById(int id);
    Task<List<Attribute>> AddAttribute(Attribute attribute);
    Task<List<Attribute>?> UpdateAttribute(int id, Attribute attribute);
    Task<List<Attribute>?> DeleteAttribute(int id);
}
