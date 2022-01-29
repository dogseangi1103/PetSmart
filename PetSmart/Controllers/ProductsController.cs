using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetSmart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet(Name = "GetProducts")]
        public IActionResult Get()
        {
            // Todo: DI
            var productServices = new ProductService();
            var products = productServices.GetProducts();
            return Ok(products);
        }
    }
}
