using RestarauntBLL.Models.Ingredient;

namespace RestarauntBLL.Services.Abstract
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientDto>> GetIngredientsAsync();
        Task DeleteIngredient(long id);
        Task CreateIngredient(IngredientCreateDto ingredient);
    }
}
