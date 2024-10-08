using Products.API.Entities;

namespace Products.API.Services.Interfaces
{
    public interface IProductsService
    {
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product product);
        Product GetProduct(string code);
        void RemoveProduct(string code);
    }
}
