using ProductsAttributesRestApi.Models.Dtos;
using ProductsAttributesRestApi.Models.Entities;

namespace ProductsAttributesRestApi.Repositories;

public interface IProductsRepository
{
    Task<List<Product>> GetAllProducts();
    Task<Product?> GetProductById(int id);
    Task<List<Product>> AddProduct(Product product);
    Task<List<Product>?> UpdateProduct(int id, Product product);
    Task<bool> DeleteProduct(int id);
    Task<List<ProductAttribute>> GetProductAttributes(int id);
    Task<List<Product>> FilterProducts(ProductFilterRequest filter);
    Task<List<Product>> FilterProductsByAttributes(AttributeValueFilter filter);
}
