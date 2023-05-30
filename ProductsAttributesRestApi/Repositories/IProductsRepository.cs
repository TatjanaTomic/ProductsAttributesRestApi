using ProductsAttributesRestApi.Models.Entities;

namespace ProductsAttributesRestApi.Repositories;

public interface IProductsRepository
{
    Task<List<Product>> GetAllProducts();
    Task<Product?> GetProductById(int id);
    Task<List<Product>> AddProduct(Product product);
    Task<List<Product>?> UpdateProduct(int id, Product product);
    Task<List<Product>?> DeleteProduct(int id);
}
