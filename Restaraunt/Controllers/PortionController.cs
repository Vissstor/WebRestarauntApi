using Microsoft.AspNetCore.Mvc;
using Restaraunt.RestarauntSystem.BLL.Models.Dish;
using Restaraunt.RestarauntSystem.BLL.Models.Ingredient;
using Restaraunt.RestarauntSystem.BLL.Models.Portion;
using Restaraunt.RestarauntSystem.BLL.Services;
using Restaraunt.RestarauntSystem.BLL.Services.Abstract;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortionController : Controller
    {
        private readonly IPortionService _portionService;
        public PortionController(IPortionService portionService)
        {
            _portionService = portionService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PortionDto>>> GetPortionAsync()
        {
            try
            {
                var ingredients = await _portionService.GetAllPortionAsync();
                return Ok(ingredients);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpGet("properties")]
        public async Task<ActionResult<IEnumerable<PortionDto>>> GetPortionAfterFilterAsync(int weight,decimal price)
        {
            try
            {
                var ingredients = await _portionService.GetPortionFilterAsync(weight, price);
                return Ok(ingredients);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }


        [HttpPost]
        public async Task<IActionResult> CreateIngredienAsync(PortionCreateDto portionCreateDto)
        {
            await _portionService.CreatePortion(portionCreateDto);
            return NoContent();
        }
    }
}
