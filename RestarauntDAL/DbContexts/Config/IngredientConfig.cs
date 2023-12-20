using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestarauntDAL.Entities;

namespace Restaraunt.RestarauntSystem.DAL.DbContexts.Config
{
    public class IngredientConfig : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.
                Property(pr => pr.Name).HasMaxLength(60);
            builder
                .HasMany(hm=> hm.IngredientDishes)
                .WithOne(wm => wm.Ingredient)
                .HasForeignKey(hf=>hf.IngredientId).IsRequired();
        }
    }
}
