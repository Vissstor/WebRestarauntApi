using Microsoft.EntityFrameworkCore;
using Restaraunt.RestarauntSystem.DAL.Entities;

namespace Restaraunt.RestarauntSystem.DAL.DbContexts
{
    public static class ModelBuilderExtensions
    {
        public static void Seed<T>(this ModelBuilder builder, List<T> list) where T : class
        {
            builder.Entity<T>().HasData(list);
        }
        public static List<Ingredient> GetIngredients()
        {
            return new List<Ingredient>
            {
               new Ingredient {Id=1, Name = "Chicken" },
               new Ingredient {Id=2,Name = "Spinach" },
               new Ingredient {Id=3, Name = "Salmon" },
               new Ingredient {Id=4,Name = "Avocado" },
               new Ingredient {Id=5,Name = "Turkey" },
               new Ingredient {Id=6,Name = "Onion" },
               new Ingredient {Id=7,Name = "Potato" },
               new Ingredient {Id=8, Name = "Garlic" }
            };
        }
    }
}
