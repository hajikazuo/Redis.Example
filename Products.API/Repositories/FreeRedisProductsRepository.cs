using FreeRedis;
using Products.API.Entities;
using Products.API.Repositories.Interfaces;
using System.Text.Json;

namespace Products.API.Repositories
{
    public class FreeRedisProductsRepository : IProductsRepository
    {
        private readonly static RedisClient _client = new RedisClient("127.0.0.1:6379");

        public IEnumerable<Product> GetAllProducts()
        {
            var keys = _client.Keys("*");

            List<Product> products = new List<Product>();

            foreach (var key in keys)
            {
                string json = _client.Get<string>(key);

                if (string.IsNullOrEmpty(json))
                {
                    return null;
                }

                Product product = JsonSerializer.Deserialize<Product>(json);
                products.Add(product);
            }

            return products;
        }

        public Product GetProduct(string code)
        {
            string json = _client.Get<string>(code);
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }
            return JsonSerializer.Deserialize<Product>(json);
        }

        public void AddOrUpdateProduct(Product product)
        {
            string json = JsonSerializer.Serialize(product);
            _client.Set(product.Code, json);
        }

        public void DeleteProduct(string code)
        {
            _client.Del(code);
        }
    }
}
