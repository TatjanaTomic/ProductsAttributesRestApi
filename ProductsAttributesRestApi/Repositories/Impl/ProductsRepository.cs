using Microsoft.EntityFrameworkCore;
using ProductsAttributesAPI.Data;
using ProductsAttributesRestApi.Exceptions;
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

    public async Task<Product> AddProduct(Product product)
    {
        var productEntity = await _dataContext.Products.AddAsync(product);
        _dataContext.SaveChanges();
        return productEntity.Entity;
    }

    public async Task AddProductAttributes(int idProduct, int idAttribute, string value)
    {
        var pa = await _dataContext.ProductAttributes.SingleOrDefaultAsync(pa => pa.ProductId == idProduct && pa.AttributeId == idAttribute);
        if (pa == null)
        {
            _dataContext.ProductAttributes.Add(new ProductAttribute() { AttributeId = idAttribute, ProductId = idProduct, Value = value });
            await _dataContext.SaveChangesAsync();
        }
        else
        {
            pa.Value = value; 
            await _dataContext.SaveChangesAsync();
        }
    }

    public async Task<Product> UpdateProduct(int id, Product product)
    {
        var result = _dataContext.Products.Find(id) ?? throw new NotFoundException();

        result.Name = product.Name;
        result.Manufacturer = product.Manufacturer;
        result.Code = product.Code;
        result.UnitOfMeasurement = product.UnitOfMeasurement;

        await _dataContext.SaveChangesAsync();

        return result;
    }

    public async Task<bool> DeleteProduct(int id)
    {
        var result = await _dataContext.Products.FindAsync(id);

        if (result is null)
            return false;

        _dataContext.Products.Remove(result);
        await _dataContext.SaveChangesAsync();

        return true;
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

    public async Task<List<Product>> FilterProductsByAttributes(AttributeValueFilter filter)
    {
        var productsAttributes = await _dataContext.ProductAttributes
            .Where(pa => pa.AttributeId == filter.AttributeId && pa.Value == filter.Value).ToListAsync();

        List<Product> products = new();
        foreach(var pa in productsAttributes)
        {
            var product = await _dataContext.Products.FindAsync(pa.ProductId);
            if(product is not null)
                products.Add(product);
        }
        return products;
    }
}
