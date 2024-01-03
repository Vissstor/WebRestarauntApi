using RestarauntDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntDAL.Specifications
{
    public class OrderByIdSpecification : Specification<Order>
    {
        public OrderByIdSpecification(long id)
        {
            CustomCondition = x=> x.Id == id;
            AddInclude(x => x.OrdersDetail);
        }
    }
}
