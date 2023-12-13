namespace Restaraunt.RestarauntSystem.DAL.Entities
{
    public class Portion : BaseEntity
    {
        public Dish? Dish { get; set; }
        public long DishId { get; set; }
        public int Weight { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }

    }
}
