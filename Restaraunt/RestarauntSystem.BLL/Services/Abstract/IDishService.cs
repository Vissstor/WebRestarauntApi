using Restaraunt.RestarauntSystem.BLL.Models.Dish;
using Restaraunt.RestarauntSystem.DAL.Entities;

namespace Restaraunt.RestarauntSystem.BLL.Services.Abstract
{
    public interface IDishService
    {
        Task<IEnumerable<DishDto>> GetAllDishiesAsync();
        Task<DishDto> GetDishByIdAsync(long id);
        Task CreateDishAsync(DishCreateDto dish);
        Task DeleteDishAsync(long id);
        Task UpdateDish(long id, UpdateDishDto dishDto);
    }
}