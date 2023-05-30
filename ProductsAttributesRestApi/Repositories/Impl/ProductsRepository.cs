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

    public Task<List<Product>?> UpdateProduct(int id, Product product)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>?> DeleteProduct(int id)
    {
        throw new NotImplementedException();
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
