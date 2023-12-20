namespace RestarauntDAL.Entities
{
    public class Dish : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Portion>? Portions { get; set; }
        public ICollection<IngredientDish>? IngredientsDishes { get; set; }
    }
}
