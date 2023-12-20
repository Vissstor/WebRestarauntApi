using RestarauntBLL.Models.Portion;

namespace RestarauntBLL.Models.Dish
{
    public class DishDto
    {
        public long Id {  get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public ICollection<PortionForDishDto> Portions { get; set; }

        public ICollection<long> IngredientsId { get; set; }


    }
}

