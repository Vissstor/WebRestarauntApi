using Microsoft.EntityFrameworkCore;
using Restaraunt.RestarauntSystem.DAL.DbContexts.Config;
using Restaraunt.RestarauntSystem.DAL.Entities;

namespace Restaraunt.RestarauntSystem.DAL.DbContexts
{
    public class RestarauntContext : DbContext
    {
        public DbSet<Dish> Dishies { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<IngredientDish> IngredientsDishies { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public DbSet<Portion> Portions { get; set; } = null!;
        public RestarauntContext(DbContextOptions<RestarauntContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DishConfig).Assembly);
            builder.Seed<Ingredient>(ModelBuilderExtensions.GetIngredients());
            base.OnModelCreating(builder);
        }

    }
}
