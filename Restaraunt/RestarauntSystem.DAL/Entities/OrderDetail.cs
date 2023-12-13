using System.Diagnostics.Contracts;

namespace Restaraunt.RestarauntSystem.DAL.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Order? order { get; set; }
        public long orderId { get; set; }
        public Portion? portion { get; set; }
        public long portionId { get; set; }

    }
}
