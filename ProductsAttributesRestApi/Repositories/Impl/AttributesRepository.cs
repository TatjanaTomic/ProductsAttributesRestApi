using Microsoft.EntityFrameworkCore;
using ProductsAttributesAPI.Data;

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

    public async Task<List<Attribute>> AddAttribute(Attribute attribute)
    {
        _dataContext.Attributes.Add(attribute);
        _dataContext.SaveChanges();
        return await _dataContext.Attributes.ToListAsync();
    }

    public async Task<List<Attribute>?> UpdateAttribute(int id, Attribute attribute)
    {
        var result = _dataContext.Attributes.Find(id);

        if (result is null)
            return null;

        result.Name = attribute.Name;
        result.Units = attribute.Units;

        _dataContext.SaveChanges();

        return await _dataContext.Attributes.ToListAsync();
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
