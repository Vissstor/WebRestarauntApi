using Restaraunt.RestarauntSystem.BLL.Models.Ingredient;
using System.Collections;

namespace Restaraunt.RestarauntSystem.BLL.Models.Dish
{
    public class DishCreateDto
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public ICollection<long> IngredientsId { get; set; }
    }
}
