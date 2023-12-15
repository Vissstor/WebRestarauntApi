namespace Restaraunt.RestarauntSystem.DAL.Entities
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public ICollection <IngredientDish>? IngredientDishes { get; set; }
    }
}
