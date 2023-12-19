using System.Data;

namespace Restaraunt.RestarauntSystem.BLL.Models.Order
{
    public class NewOrderDto
    {
        public List<OrderItemDto> PortionsId { get; set; }
        public int TableNumber { get; set; }
    }
}
