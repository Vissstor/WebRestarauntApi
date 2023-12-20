using RestarauntBLL.Models.Order;
using RestarauntDAL;

namespace RestarauntBLL.Services.Abstract
{
    public interface IOrderService
    {
        Task DeleteOrderAsync(long id);
        Task<IEnumerable<OrderDto>> GetAllOrderAsync();
        Task<OrderDto> GetOrderByIdAsync(long id);
        Task<IEnumerable<OrderDto>> GetOrderByStatusOrderAsync(StatusOrder statusOrder);
        Task CreateOrderAsync(NewOrderDto newOrder);
        Task UpdateOrderAsync(long id, UpdateOrderDto orderToUpdate);
    }
}