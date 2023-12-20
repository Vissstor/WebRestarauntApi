
using RestarauntBLL.Models.Dish;

namespace RestarauntBLL.Services.Abstract
{
    public interface IDishService
    {
        Task<IEnumerable<DishDto>> GetAllDishiesAsync();
        Task<DishDto> GetDishByIdAsync(long id);
        Task CreateDishAsync(DishCreateDto dish);
        Task DeleteDishAsync(long id);
    }
}