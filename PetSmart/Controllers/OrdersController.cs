using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetSmart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPatch("{id}", Name = "Pay")]
        public async Task<IActionResult> Pay(int id)
        {
            var order = await _orderService.Pay(id);
            return Ok(order);
        }
    }
}
