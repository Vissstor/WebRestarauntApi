using Restaraunt.RestarauntSystem.DAL;
using System.Data;

namespace Restaraunt.RestarauntSystem.BLL.Models.Order
{
    public class NewOrderDto
    {
        public List<OrderDetailDto> OrderDetailDto { get; set; }
        public int TableNumber { get; set; }


    }
}

