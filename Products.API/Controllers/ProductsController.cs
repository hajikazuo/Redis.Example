using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.API.Entities;
using Products.API.Services.Interfaces;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return _productsService.GetAllProducts();
        }

        [HttpGet("{code}")]
        public Product Get(string code)
        {
            return _productsService.GetProduct(code);
        }

        [HttpPost]
        public void Post([FromBody] Product value)
        {
            _productsService.AddProduct(value);
        }

        [HttpDelete("{code}")]
        public void Delete(string code)
        {
            _productsService.RemoveProduct(code);
        }

    }
}
