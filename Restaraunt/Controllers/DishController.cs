using Microsoft.AspNetCore.Mvc;
using Restaraunt.RestarauntSystem.BLL.Models.Dish;
using Restaraunt.RestarauntSystem.BLL.Services.Abstract;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : Controller
    {
        private readonly IDishService _dishService;
        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetDishiesAsync()
        {
            try
            {
                var ingredients = await _dishService.GetAllDishiesAsync();
                return Ok(ingredients);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DishDto>> GetDishByIdAsync(long id)
        {
            try
            {
                var dish = await _dishService.GetDishByIdAsync(id);
                return Ok(dish);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPost]
        public async Task<IActionResult> CreateDishAsync(DishCreateDto dish)
        {
            await _dishService.CreateDishAsync(dish);
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteDishAsync(long id)
        {
            await _dishService.DeleteDishAsync(id);
            return NoContent();
        }
        [HttpPut("Id")]
        public async Task<IActionResult> UpdateDish(long id,UpdateDishDto updateDish)
        {
            await _dishService.UpdateDish(id, updateDish);
            return NoContent();
        }

    }
}
