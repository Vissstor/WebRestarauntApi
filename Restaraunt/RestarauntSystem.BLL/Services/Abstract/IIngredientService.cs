using Restaraunt.RestarauntSystem.BLL.Models.Ingredient;

namespace Restaraunt.RestarauntSystem.BLL.Services.Abstract
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientDto>> GetIngredientsAsync();
        Task DeleteIngredient(long id);
        Task CreateIngredient(IngredientCreateDto ingredient);
    }
}
