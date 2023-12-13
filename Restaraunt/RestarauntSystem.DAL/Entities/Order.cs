namespace Restaraunt.RestarauntSystem.DAL.Entities
{
    public class Order : BaseEntity
    {
        public DateTime DateOrder { get; set; }
        public int Status { get; set; }
        public int TableNumber { get; set; }
        public IEnumerable<OrderDetail> Portions { get; set; }
    }
}
