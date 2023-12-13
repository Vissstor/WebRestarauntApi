using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaraunt.RestarauntSystem.DAL.Entities;

namespace Restaraunt.RestarauntSystem.DAL.DbContexts.Config
{
    public class DishConfig : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder
                .HasMany(h => h.Portions)
                .WithOne(w => w.Dish)
                .HasForeignKey(h => h.Id)
                .IsRequired();
            builder
                .HasMany(hm => hm.IngredientsDishes)
                .WithOne(wo => wo.Dish)
                .HasForeignKey(h => h.Id)
                .IsRequired();
        }
    }
}
