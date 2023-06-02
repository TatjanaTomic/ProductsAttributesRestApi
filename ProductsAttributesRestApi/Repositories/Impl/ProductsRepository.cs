using Microsoft.EntityFrameworkCore;
using ProductsAttributesAPI.Data;
using ProductsAttributesRestApi.Models.Dtos;
using ProductsAttributesRestApi.Models.Entities;

namespace ProductsAttributesRestApi.Repositories.Impl;

public class ProductsRepository : BaseRepository, IProductsRepository
{
    public ProductsRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public async Task<List<Product>> GetAllProducts()
    {
        return await _dataContext.Products.ToListAsync();
    }

    public async Task<Product?> GetProductById(int id)
    {
        return await _dataContext.Products.FindAsync(id);
    }

    public async Task<List<Product>> AddProduct(Product product)
    {
        _dataContext.Products.Add(product);
        _dataContext.SaveChanges();
        return await _dataContext.Products.ToListAsync();
    }

    public async Task<List<Product>?> UpdateProduct(int id, Product product)
    {
        var result = _dataContext.Products.Find(id);

        if (result is null)
            return null;

        result.Name = product.Name;
        result.Manufacturer = product.Manufacturer;
        result.Code = product.Code;
        result.UnitOfMeasurement = product.UnitOfMeasurement;

        _dataContext.SaveChanges();

        return await _dataContext.Products.ToListAsync();
    }

    public async Task<List<Product>?> DeleteProduct(int id)
    {
        var result = await _dataContext.Products.FindAsync(id);

        if (result is null)
            return null;

        _dataContext.Products.Remove(result);
        await _dataContext.SaveChangesAsync();

        return await _dataContext.Products.ToListAsync();
    }

    public async Task<List<ProductAttribute>> GetProductAttributes(int id)
    {
        var result = await _dataContext.ProductAttributes.Where(pa => pa.ProductId == id).ToListAsync();
        foreach (var r in result)
            r.Attribute = _dataContext.Attributes.Find(r.AttributeId)!;
        return result;
    }

    public async Task<List<Product>> FilterProducts(ProductFilterRequest filter)
    {
        return await _dataContext.Products
            .Where(p => filter.Id == null || filter.Id == p.Id)
            .Where(p => filter.Name == null || filter.Name == p.Name)
            .Where(p => filter.Code == null || filter.Code == p.Code)
            .Where(p => filter.Manufacturer == null || filter.Manufacturer == p.Manufacturer)
            .Where(p => filter.UnitOfMeasurement == null || filter.UnitOfMeasurement == p.UnitOfMeasurement)
            .ToListAsync();
    }
}
