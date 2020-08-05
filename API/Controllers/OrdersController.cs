using AppGr8.WebApiECommerce.Services;
using AppGr8.WebApiECommerce.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AppGr8.WebApiECommerce.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrdersController : Controller
    {
        private readonly OrderService orderService;

        public OrdersController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllTickets()
        {
            var orders = orderService.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (orderService.Contains(id))
            {
                var order = orderService.Get(id);
                return Ok(order);
            }
            else
                return NotFound($"Unable to find order with id {id}");
        }

        [HttpPost("Create")]
        public IActionResult Create(Order order)
        {
            var createdOrder = orderService.Create(order);
            return Ok(createdOrder);
        }

        [HttpPut("Update")]
        public IActionResult Update(Order order)
        {
            if (orderService.Contains(order.Id))
            {
                var updatedOrder = orderService.Update(order);
                return Ok(updatedOrder);
            }
            else
                return NotFound($"Unable to find order with id {order.Id}");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, JsonPatchDocument<Order> patch)
        {
            if (orderService.Contains(id))
            {
                var updatedOrder = orderService.Update(id, patch);
                return Ok(updatedOrder);
            }
            else
                return NotFound($"Unable to find order with id {id}");
        }
    }
}
