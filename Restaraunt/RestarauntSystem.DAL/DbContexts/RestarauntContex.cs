using Microsoft.EntityFrameworkCore;
using Restaraunt.RestarauntSystem.DAL.Entities;

namespace Restaraunt.RestarauntSystem.DAL.DbContexts
{
    public class RestarauntContex : DbContext
    {
        public DbSet<Dish> Dishies { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<IngredientDish> IngredientsDishies { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public DbSet<Portion> Portions { get; set; } = null!;
        public RestarauntContex(DbContextOptions<RestarauntContex> options)
            : base(options)
        {

        }


    }
}
