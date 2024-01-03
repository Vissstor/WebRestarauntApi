using RestarauntDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntDAL.Specifications
{
    public class DishByIdSpecification : Specification<Dish>
    {
        public DishByIdSpecification(long id) 
        {
            CustomCondition=x => x.Id == id;
            AddInclude(x => x.IngredientsDishes);
            AddInclude(x => x.Portions);
        }
    }
}
