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
               new Ingredient {Id=1, Name = "Cucumber" },
               new Ingredient {Id=2,Name = "Spinach" },
               new Ingredient {Id=3, Name = "Salmon" },
               new Ingredient {Id=4,Name = "Avocado" },
               new Ingredient {Id=5,Name = "Turkey" },
               new Ingredient {Id=6,Name = "Onion" },
               new Ingredient {Id=7,Name = "Potato" },
               new Ingredient {Id=8, Name = "Garlic" },
               new Ingredient {Id=9,Name = "Chiken" }
            };
        }
        public static List<Dish> GetDishies()
        {
            return new List<Dish>
            {
               new Dish {Id=1, Name = "Chicken and Potato Gratin" ,Description="A comforting and hearty dish featuring layers of tender chicken, sliced potatoes, caramelized onions, and a rich garlic-infused cream sauce. Baked until golden and bubbling, this gratin is the epitome of savory indulgence."},
               new Dish {Id=2,Name = "Turkey with Spinach and Avocado", Description="A light and nutritious dish that combines lean turkey with fresh spinach and creamy avocado. The turkey is seasoned to perfection, and the dish is topped with slices of ripe avocado for a burst of flavor and a touch of indulgence."},
               new Dish {Id=3, Name = "Baked Salmon with Potato and Onion" , Description="An elegant and flavorful dish featuring succulent baked salmon, accompanied by perfectly roasted potatoes and caramelized onions. The salmon is seasoned with herbs and spices, creating a harmonious blend of textures and tastes."}
            };
        }

       
    }
}
