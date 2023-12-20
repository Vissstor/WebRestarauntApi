using System.Diagnostics.Contracts;

namespace RestarauntDAL.Entities
{
    public class OrderDetail
    {
        public Order? Order { get; set; }
        public long OrderId { get; set; }
        public Portion? Portion { get; set; }
        public long PortionId { get; set; }

    }
}
