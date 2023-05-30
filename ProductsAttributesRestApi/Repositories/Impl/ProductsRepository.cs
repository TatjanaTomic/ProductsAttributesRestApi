using Microsoft.EntityFrameworkCore;
using ProductsAttributesAPI.Data;
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

    public Task<List<Product>> AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>?> UpdateProduct(int id, Product product)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>?> DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }
}
