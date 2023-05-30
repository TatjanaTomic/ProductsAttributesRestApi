using Microsoft.EntityFrameworkCore;
using ProductsAttributesAPI.Data;
using ProductsAttributesRestApi.Models.Entities;

namespace ProductsAttributesRestApi.Repositories.Impl;

public class ProductsRepository : BaseRepository, IProductsRepository
{
    public ProductsRepository(DataContext dataContext) : base(dataContext)
    {
    }

    async Task<List<Product>> IProductsRepository.GetAllProducts()
    {
        return await _dataContext.Products.ToListAsync();
    }

    Task<Product?> IProductsRepository.GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    Task<List<Product>> IProductsRepository.AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    Task<List<Product>?> IProductsRepository.UpdateProduct(int id, Product product)
    {
        throw new NotImplementedException();
    }

    Task<List<Product>?> IProductsRepository.DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }
}
