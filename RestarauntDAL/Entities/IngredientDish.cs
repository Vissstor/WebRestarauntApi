using System.ComponentModel.DataAnnotations.Schema;

namespace RestarauntDAL.Entities
{
    public class IngredientDish
    {

        public Ingredient? Ingredient { get; set; }
        public long IngredientId { get; set; }

        public Dish? Dish { get; set; }
        public long DishId { get; set; }
    }
}
