using Restaraunt.RestarauntSystem.BLL.Models.Order;
using Restaraunt.RestarauntSystem.DAL;

namespace Restaraunt.RestarauntSystem.BLL.Services.Abstract
{
    public interface IOrderService
    {
        Task DeleteOrderAsync(long id);
        Task<IEnumerable<OrderDto>> GetAllOrderAsync();
        Task<OrderDto> GetOrderByIdAsync(long id);
        Task<IEnumerable<OrderDto>> GetOrderByStatusOrderAsync(StatusOrder statusOrder);
        Task CreateOrderAsync(NewOrderDto newOrder);
    }
}