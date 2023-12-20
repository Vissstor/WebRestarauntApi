using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestarauntBLL.Models.Ingredient;
using RestarauntDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestsRestaraunt.IntegrationTests
{
    public class IngredientControllerIntegrationTests : TestsDataBaseIntegrationTests
    {
        public IngredientControllerIntegrationTests(CustomWebFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetIngredients_ReturnsSuccessStatusCodeAndNonEmptyList()
        {
            // Arrange
            var response = await client.GetAsync("/api/Ingredient");

            // Act & Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);


            var ingredients = JsonConvert.DeserializeObject<List<IngredientDto>>(await response.Content.ReadAsStringAsync());

            Assert.NotNull(ingredients);
            Assert.NotEmpty(ingredients);

            foreach (var ingredient in ingredients)
            {
                Assert.NotNull(ingredient.Name);
            }
        }

        [Fact]
        public async Task DeleteIngredient_ReturnsNoContentStatusCodeAndRemovesFromDatabase()
        {
            // Arrange
            long idToDelete = 1;


            var ingredientToDelete = new Ingredient { Id = idToDelete, Name = "TestIngredient" };
            context.Ingredients.Add(ingredientToDelete);
            await context.SaveChangesAsync();


            var response = await client.DeleteAsync($"/api/Ingredient/{idToDelete}");
            await context.SaveChangesAsync();
            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task CreateIngredient_ReturnsNoContentStatusCodeAndAddsToDatabase()
        {
            // Arrange
            var ingredientDto = new IngredientCreateDto
            {
                Name = "TestIngredient",

            };

            var content = new StringContent(JsonConvert.SerializeObject(ingredientDto), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/api/Ingredient", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            var addedIngredient = await context.Ingredients.FirstOrDefaultAsync(i => i.Name == ingredientDto.Name);
            Assert.NotNull(addedIngredient);
        }

    }
}
