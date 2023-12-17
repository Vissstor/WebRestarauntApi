namespace Restaraunt.RestarauntSystem.BLL.Models.Portion
{
    public class PortionCreateDto
    {
        public int Weight { get; set; }
        public decimal Price { get; set; }
        public long DishId {  get; set; }

    }
}
