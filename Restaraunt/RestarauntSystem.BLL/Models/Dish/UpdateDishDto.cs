using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Restaraunt.RestarauntSystem.BLL.Models.Dish
{
    public class UpdateDishDto
    {
        public string Name {  get; set; }
        public string Description { get; set; }

    }
}
