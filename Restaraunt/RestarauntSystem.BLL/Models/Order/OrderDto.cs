namespace Restaraunt.RestarauntSystem.BLL.Models.Order
{
    public class OrderDto
    {
        public long Id { get; set; }
        public int TableNumber {  get; set; }
        public DateTime TimeOrder {  get; set; }
        public List<long> PortionsId { get; set; }
        
    }
}
