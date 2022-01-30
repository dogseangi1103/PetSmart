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

        [HttpGet("{id}", Name = "GetOrderPrice")]
        public async Task<IActionResult> GetOrderPrice(int id)
        {
            var orderPrice = await _orderService.CalculateOrderPrice(id);
            return Ok(orderPrice);
        }

        [HttpPatch("{id}", Name = "Pay")]
        public async Task<IActionResult> Pay(int id)
        {
            var order = await _orderService.Pay(id);
            return Ok(order);
        }
    }
}
