using Restaraunt.RestarauntSystem.DAL.Entities;

namespace Restaraunt.RestarauntSystem.BLL.Models.Dish
{
    public class DishDto
    {
        public long Id { get; set; }
        public string Name=string.Empty;
        public string Description = string.Empty;
        public List<long> IngredientsId { get; set; } 
       
    }
}
