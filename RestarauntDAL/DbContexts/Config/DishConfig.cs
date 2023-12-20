using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestarauntDAL.Entities;

namespace Restaraunt.RestarauntSystem.DAL.DbContexts.Config
{
    public class DishConfig : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.
                Property(pr=>pr.Name).HasMaxLength(60);
            builder.
                Property(pr => pr.Description).HasMaxLength(256);
            builder
                .HasMany(h => h.Portions)
                .WithOne(w => w.Dish)
                .HasForeignKey(h => h.DishId)
                .IsRequired();
            builder
                .HasMany(hm => hm.IngredientsDishes)
                .WithOne(wo => wo.Dish)
                .HasForeignKey(h => h.DishId)
                .IsRequired();
        }
    }
}
