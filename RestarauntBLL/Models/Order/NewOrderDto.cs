using Restaraunt.RestarauntSystem.DAL;
using System.Data;

namespace RestarauntBLL.Models.Order
{
    public class NewOrderDto
    {
        public List<long> PortionsId { get; set; }
        public int TableNumber { get; set; }

    }
}

