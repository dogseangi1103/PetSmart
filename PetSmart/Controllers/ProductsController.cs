using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetSmart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = "GetProducts")]
        public IActionResult Get(string? keyword)
        {
            var products = _productService.GetProducts(keyword);
            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(int id)
        {
            var product = _productService.GetProduct(id);
            return Ok(product);
        }
    }
}
