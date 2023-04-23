using Microsoft.AspNetCore.Mvc;
using PizzaStore.Models;
using PizzaStore.Services.Orders.Contract;


namespace PizzaStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService) {
            this.orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel?>> Get(int id)
        {

            var order = await orderService.Get(id);

            if (order != null)
            {
                return Ok(new OrderModel
                {
                    OrderId = order.OrderId,
                    Price = order.Amount
                });
            }

            return BadRequest();
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] OrderModel order)
        {
            var orderId = await orderService.Add(order.Price);
            return Ok(orderId);
        }
    }
}
