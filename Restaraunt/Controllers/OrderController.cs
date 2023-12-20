using Microsoft.AspNetCore.Mvc;
using RestarauntBLL.Models.Order;
using RestarauntBLL.Services.Abstract;
using RestarauntDAL;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrderAllAsync()
        {
            try
            {
                var order = await _orderService.GetAllOrderAsync();
                return Ok(order);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("status")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrderByNumberTable(StatusOrder status)
        {
            try
            {
                var order = await _orderService.GetOrderByStatusOrderAsync(status);
                return Ok(order);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(NewOrderDto order)
        {
            await _orderService.CreateOrderAsync(order);
            return NoContent();
        }
        [HttpGet("Id")]
        public async Task<ActionResult<OrderDto>> GetOrderById(long id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                return Ok(order);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteOrder(long id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }

        [HttpPut("Id")]

        public async Task<IActionResult> UpdateOrderStatus(long id,UpdateOrderDto updateOrderDto)
        {
            await _orderService.UpdateOrderAsync(id, updateOrderDto);
            return NoContent();
        }
    }
}
