using Restaraunt.RestarauntSystem.BLL.Models.Portion;

namespace Restaraunt.RestarauntSystem.BLL.Models.Dish
{
    public class DishCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<long> IngredientsId { get; set; }
        public ICollection<PortionCreateDto> Portions { get; set; }
    }
}

