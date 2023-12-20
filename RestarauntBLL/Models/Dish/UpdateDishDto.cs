using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace RestarauntBLL.Models.Dish
{
    public class UpdateDishDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
