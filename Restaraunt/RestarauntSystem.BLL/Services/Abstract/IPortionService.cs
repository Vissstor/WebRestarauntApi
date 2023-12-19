using Restaraunt.RestarauntSystem.BLL.Models.Portion;

namespace Restaraunt.RestarauntSystem.BLL.Services.Abstract
{
    public interface IPortionService
    {

        Task<IEnumerable<PortionDto>> GetAllPortionAsync();
        Task UpdatePortionAsync(long id, PortionForDishDto orderToUpdate);
        //Task<IEnumerable<PortionDto>> GetPortionFilterAsync(int weihgt, decimal price);
    }
}