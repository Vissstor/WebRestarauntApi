using RestarauntBLL.Models.Portion;

namespace RestarauntBLL.Services.Abstract
{
    public interface IPortionService
    {

        Task<IEnumerable<PortionDto>> GetAllPortionAsync();
        Task UpdatePortionAsync(long id, PortionForDishDto orderToUpdate);
        //Task<IEnumerable<PortionDto>> GetPortionFilterAsync(int weihgt, decimal price);
    }
}