using Products.API.Entities;
using Products.API.Repositories.Interfaces;
using Products.API.Services.Interfaces;

namespace Products.API.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _repository;

        public ProductsService(IProductsRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        public void AddProduct(Product product)
        {
            _repository.AddOrUpdateProduct(product);
        }

        public Product GetProduct(string code)
        {
           return _repository.GetProduct(code);
        }

        public void RemoveProduct(string code)
        {
            _repository.DeleteProduct(code);    
        }
    }
}
