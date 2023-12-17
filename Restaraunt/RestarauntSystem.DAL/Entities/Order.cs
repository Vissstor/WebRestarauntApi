namespace Restaraunt.RestarauntSystem.DAL.Entities
{
    public class Order : BaseEntity
    {
        public DateTime DateOrder { get; set; }
        public StatusOrder Status { get; set; }
        public int TableNumber { get; set; }
        public IEnumerable<OrderDetail> OrdersDetail { get; set; }
    }
}
