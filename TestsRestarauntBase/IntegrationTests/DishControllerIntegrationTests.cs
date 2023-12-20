using RestarauntBLL.Models.Dish;
using System.Net.Http.Json;
using System.Net;
using RestarauntBLL.Models.Portion;
using RestarauntDAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace TestsRestaraunt.IntegrationTests
{
    public class DishControllerIntegrationTests : TestsDataBaseIntegrationTests
    {
        public DishControllerIntegrationTests(CustomWebFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetDishiesAsync_ReturnsOkResult()
        {
            // Arrange

            //Act
            var response = await client.GetAsync("/api/Dish");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetDishByIdAsync_ReturnsBadResult()
        {
            // Arrange
            var dishId = -111;

            // Act
            var response = await client.GetAsync($"/api/Dish/{dishId}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CreateDishAsync_ReturnsNoContentResult()
        {
            // Arrange
            var dishCreateDto = new DishCreateDto
            {
                Name = "TestDish",
                Description = "Test description",
                IngredientsId = new List<long> { 1, 2, 3 },
                Portions = new List<PortionForDishDto>
                {
                    new PortionForDishDto { Weight = 200, Price = 10.99m },
                }
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/Dish", dishCreateDto);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            var addedDish = await context.Dishies.FirstOrDefaultAsync(d => d.Name == dishCreateDto.Name);
            Assert.NotNull(addedDish);
        }

        [Fact]
        public async Task DeleteDishAsync_ReturnsNoContentResult()
        {
            // Arrange
            long dishIdToDelete = 1;
            var dishToDelete = new Dish { Id = dishIdToDelete, Name = "TestDish", Description = "Test Description" };
            context.Dishies.Add(dishToDelete);
            await context.SaveChangesAsync();

            // Act
            var response = await client.DeleteAsync($"/api/Dish/{dishIdToDelete}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

    }
}