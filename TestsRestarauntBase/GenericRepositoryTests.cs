using Microsoft.EntityFrameworkCore;
using RestarauntDAL.Entities;
using RestarauntDAL.Repositories;
using RestarauntDAL.Specifications;
using System.Linq.Expressions;

using TestsRestaraunt;

namespace TestsRestarauntBase
{
    public class GenericRepositoryTests : TestsBaseData
    {

        [Fact]
        public async Task GetAllObjects_ShouldReturnAllObjects()
        {
            // Arrange
            var dishesContext = context.Dishies.ToList();

            // Act
            var dishes = await repository.GetAllObjectAsync();

            // Assert
            Assert.Equal(dishesContext, dishes);
        }

        [Fact]
        public async Task GetAllInformationObjects_ShouldReturnAllObjectsWithIncludes()
        {
            // Arrange
            var dishWithIngredientsContext = context.Dishies
                .Include(d => d.IngredientsDishes)
                .ToList();

            // Act
            var dishWithIngredients = await repository.GetObjectAsync(new DishIncludeSpecification());

            // Assert
            Assert.Equal(dishWithIngredientsContext, dishWithIngredients);
        }


 
        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectObject()
        {
            // Arrange
            var testDish = GetTestDish();
            await repository.Create(testDish);
            await repository.SaveAsync();

            // Act
            var resultDish = await repository.GetByIdAsync(testDish.Id);

            // Assert
            Assert.Equal(testDish, resultDish);
        }

        [Fact]
        public async Task GetByIdIncludeAsync_ShouldReturnCorrectObjectWithIncludes()
        {
            // Arrange
            var testDish = GetTestDish();
            await repository.Create(testDish);
            await repository.SaveAsync();

            // Act
            var resultDish = await repository.GetByIdIncludeAsync(new DishByIdSpecification(1));

            // Assert
            Assert.Equal(testDish, resultDish);
        }

        [Fact]
        public async Task Delete_ShouldRemoveObject()
        {
            // Arrange
            var testDish = GetTestDish();
            await repository.Create(testDish);

            // Act
            repository.Delete(testDish);
            await repository.SaveAsync();

            // Assert
            var resultDish = await repository.GetByIdAsync(testDish.Id);
            Assert.Null(resultDish);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateObject()
        {
            // Arrange
            var testDish = GetTestDish();
            await repository.Create(testDish);
            await repository.SaveAsync();

            // Act
            testDish.Name = "Updated Dish";
            await repository.UpdateAsync(testDish);
            await repository.SaveAsync();

            // Assert
            var updatedDish = await repository.GetByIdAsync(testDish.Id);
            Assert.Equal(testDish.Name, updatedDish.Name);
        }

        [Fact]
        public async Task CreateArange_ShouldAddRangeOfObjects()
        {
            // Arrange
            var dishesToAdd = new List<Dish>
                {
                   GetTestDish(),
                   GetTestDish()
                };

            // Act
            await repository.CreateArange(dishesToAdd);
            await repository.SaveAsync();

            // Assert
            var addedDishes = await repository.GetAllObjectAsync();
            Assert.Equal(dishesToAdd.Count, addedDishes.Count());
            Assert.Contains(dishesToAdd[0], addedDishes);
            Assert.Contains(dishesToAdd[1], addedDishes);
        }


        public Dish GetTestDish()
        {
            return new Dish
            {
                Name = "Dish Test",
                Description = "Main Course",
                Portions = new List<Portion>
                    {
                       new Portion { Weight = 252,Price=233 },
                       new Portion { Weight = 22352,Price=22333 }
                    }
            };
        }
    }
}