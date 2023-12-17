using Restaraunt.RestarauntSystem.BLL.Models.Portion;

namespace Restaraunt.RestarauntSystem.BLL.Services.Abstract
{
    public interface IPortionService
    {
        Task CreatePortion(PortionCreateDto portion);
        Task<IEnumerable<PortionDto>> GetAllPortionAsync();
        Task<IEnumerable<PortionDto>> GetPortionFilterAsync(int weihgt, decimal price);
    }
}