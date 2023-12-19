namespace Restaraunt.RestarauntSystem.BLL.Models.Portion
{
    public class PortionDto
    {
        public long Id { get; set; }
        public int Weight { get; set; }
        public decimal Price { get; set; }
        public long DishId { get; set; }

    }
}
