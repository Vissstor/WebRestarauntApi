using RestarauntDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntDAL.Specifications
{
    public abstract class Specification<TEntity> where TEntity : class
    {
        public Expression<Func<TEntity, bool>>? CustomCondition { get; set; }
        public ICollection<Expression<Func<TEntity, object>>> CustomIncludes { get; }

        protected Specification()
        {
            CustomCondition = null;
            CustomIncludes = new List<Expression<Func<TEntity, object>>>();
        }

        public void AddInclude(Expression<Func<TEntity, object>> customIncludes)
        {
            CustomIncludes.Add(customIncludes);
        }
    }

}
