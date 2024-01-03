using RestarauntDAL.Entities;
using System.Linq.Expressions;

namespace RestarauntDAL.Specifications
{
    public class OrderIncludeSpecification : Specification<Order>
    {
        public OrderIncludeSpecification() 
        {
            AddInclude(X => X.OrdersDetail);
        }
    }
}
