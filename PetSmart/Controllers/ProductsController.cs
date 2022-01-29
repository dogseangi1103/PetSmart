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
            var products = new List<dynamic>
            {
                new { Id = 1, Name = "dog food 1" },
                new { Id = 2, Name = "dog food 2" },
                new { Id = 3, Name = "dog food 3" },
            };
            return Ok(products);
        }
    }
}
