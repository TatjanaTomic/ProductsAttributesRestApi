using Microsoft.EntityFrameworkCore;
using ProductsAttributesAPI.Data;
using ProductsAttributesRestApi.Exceptions;

namespace ProductsAttributesRestApi.Repositories.Impl;

public class AttributesRepository : BaseRepository, IAttributesRepository
{
    public AttributesRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public async Task<List<Attribute>> GetAllAttributes()
    {
        return await _dataContext.Attributes.ToListAsync();
    }

    public async Task<Attribute?> GetAttributeById(int id)
    {
        return await _dataContext.Attributes.FindAsync(id);
    }

    public async Task<Attribute> AddAttribute(Attribute attribute)
    {
        var attributeEntity = await _dataContext.Attributes.AddAsync(attribute);
        _dataContext.SaveChanges();
        return attributeEntity.Entity;
    }

    public async Task<Attribute> UpdateAttribute(int id, Attribute attribute)
    {
        var result = await _dataContext.Attributes.FindAsync(id);
        
        result.Name = attribute.Name;
        result.Units = attribute.Units;

        _dataContext.SaveChanges();

        return result;
    }

    public async Task<List<Attribute>?> DeleteAttribute(int id)
    {
        var result = await _dataContext.Attributes.FindAsync(id);

        if (result is null)
            return null;

        _dataContext.Attributes.Remove(result);
        await _dataContext.SaveChangesAsync();

        return await _dataContext.Attributes.ToListAsync();
    }
}
