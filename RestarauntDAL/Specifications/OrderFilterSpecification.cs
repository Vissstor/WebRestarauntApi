using RestarauntDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntDAL.Specifications
{
    public class OrderFilterSpecification : Specification<Order>
    {
        public OrderFilterSpecification(StatusOrder status)
        {
            CustomCondition = x => x.Status == status;
        }
    }
}
