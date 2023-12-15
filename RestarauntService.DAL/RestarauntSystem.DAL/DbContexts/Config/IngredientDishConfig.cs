using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaraunt.RestarauntSystem.DAL.Entities;
using System.Reflection.Emit;

namespace Restaraunt.RestarauntSystem.DAL.DbContexts.Config
{
    public class IngredientDishConfig : IEntityTypeConfiguration<IngredientDish>
    {
        public void Configure(EntityTypeBuilder<IngredientDish> builder)
        {
            builder
                .HasKey(e => new { e.DishId, e.IngredientId });

        }
    }
}
