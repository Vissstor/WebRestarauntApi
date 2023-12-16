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
            var ingredients = await _ingredientService.GetIngredientsAsync();
            return Ok(ingredients);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredientAsync(int id)
        {
            await _ingredientService.DeleteIngredient(id);
            return NoContent();
        }
    }
}
