using Products.API.Entities;

namespace Products.API.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        void AddOrUpdateProduct(Product product);
        Product GetProduct(string code);
        void DeleteProduct(string code);
        IEnumerable<Product> GetAllProducts();
    }
}
