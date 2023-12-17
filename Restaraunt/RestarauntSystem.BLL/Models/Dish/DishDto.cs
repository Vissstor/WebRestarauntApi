using Restaraunt.RestarauntSystem.BLL.Models.Portion;
using Restaraunt.RestarauntSystem.DAL.Entities;

namespace Restaraunt.RestarauntSystem.BLL.Models.Dish
{
    public class DishDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public ICollection<PortionDto> Portions { get; set; }


    }
}
