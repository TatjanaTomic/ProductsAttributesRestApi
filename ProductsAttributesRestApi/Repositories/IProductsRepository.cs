using ProductsAttributesRestApi.Models.Dtos;
using ProductsAttributesRestApi.Models.Entities;

namespace ProductsAttributesRestApi.Repositories;

public interface IProductsRepository
{
    Task<List<Product>> GetAllProducts();
    Task<Product?> GetProductById(int id);
    Task<Product> AddProduct(Product product);
    Task<Product> UpdateProduct(int id, Product product);
    Task<bool> DeleteProduct(int id);
    Task<List<ProductAttribute>> GetProductAttributes(int id);
    Task AddProductAttributes(int idProduct, int idAttribute, string value);
    Task<List<Product>> FilterProducts(ProductFilterRequest filter);
}
