using RestarauntBLL.Models.Portion;

namespace RestarauntBLL.Models.Dish
{
    public class DishCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<long> IngredientsId { get; set; }
        public ICollection<PortionForDishDto> Portions { get; set; }
    }
}

