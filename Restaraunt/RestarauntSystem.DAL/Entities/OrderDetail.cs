using System.Diagnostics.Contracts;

namespace Restaraunt.RestarauntSystem.DAL.Entities
{
    public class OrderDetail
    {
        public Order? Order { get; set; }
        public long OrderId { get; set; }
        public Portion? Portion { get; set; }
        public long PortionId { get; set; }

    }
}
