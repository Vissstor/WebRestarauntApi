using Microsoft.AspNetCore.Mvc;
using Restaraunt.RestarauntSystem.BLL.Models.Ingredient;
using Restaraunt.RestarauntSystem.BLL.Services;
using Restaraunt.RestarauntSystem.BLL.Services.Abstract;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : Controller
    {
        private readonly IIngredientService _ingredientService;
        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientDto>>> GetIngredientsAsync()
        {
            try
            {
                var ingredients = await _ingredientService.GetIngredientsAsync();
                return Ok(ingredients);
            } 
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredientAsync(int id)
        {
            await _ingredientService.DeleteIngredient(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateIngredienAsync(IngredientCreateDto ingredientDto)
        {
            await _ingredientService.CreateIngredient(ingredientDto);
            return NoContent();
        }
    }
}
