using Restaraunt.RestarauntSystem.BLL.Models.Portion;

namespace Restaraunt.RestarauntSystem.BLL.Models.Dish
{
    public class DishDto
    {

        public string Name { get; set; }

        public string Description { get; set; }
        public ICollection<PortionForDishDto> Portions { get; set; }

        public ICollection<long> IngredientsId { get; set; }


    }
}

