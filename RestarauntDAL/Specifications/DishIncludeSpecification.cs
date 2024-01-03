using RestarauntDAL.Entities;
namespace RestarauntDAL.Specifications
{
    public class DishIncludeSpecification : Specification<Dish>
    {
        public DishIncludeSpecification()
        {
            AddInclude(x => x.IngredientsDishes);
            AddInclude(x => x.Portions);
        }
    }
}
