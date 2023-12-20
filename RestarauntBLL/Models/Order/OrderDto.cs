using RestarauntDAL;

namespace RestarauntBLL.Models.Order
{
    public class OrderDto
    {
        public long Id { get; set; }
        public int TableNumber { get; set; }
        public DateTime DateOrder { get; set; }

        public StatusOrder Status { get; set; }
        public ICollection<long> PortionsDto { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
