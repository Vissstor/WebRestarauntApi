using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestarauntBLL.Models.Ingredient;
using RestarauntBLL.Models.Portion;
using RestarauntDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace TestsRestaraunt.IntegrationTests
{
    public class PortionControllerIntegrationTests : TestsDataBaseIntegrationTests
    {
        public PortionControllerIntegrationTests(CustomWebFactory<Program> factory) : base(factory)
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
        }
        public async Task GetPortion_ReturnsSuccessStatusCodeAndNonEmptyList()
        {
            // Arrange
            var response = await client.GetAsync("/api/Portion");

            // Act & Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var ingredients = JsonConvert.DeserializeObject<List<PortionDto>>(await response.Content.ReadAsStringAsync());

            Assert.NotNull(ingredients);
            Assert.NotEmpty(ingredients);

            foreach (var ingredient in ingredients)
            {
                Assert.NotNull(ingredient.Price);
            }

        }

        [Fact]
        public async Task UpdatePortion_ReturnsNoContentStatusCode()
        {
            // Arrange
            long idToUpdate = 1;
            var portionToUpdate = new PortionForDishDto { Weight = 300, Price = 15.99m };

            var existingPortion = new Portion { Id = idToUpdate, Weight = 200, Price = 10.99m };
            await context.Portions.AddAsync(existingPortion);
            await context.SaveChangesAsync();

            // Act
            var response = await client.PutAsJsonAsync($"/api/Portion/{idToUpdate}", portionToUpdate);

            // Assert
            
            var updatedPortion = await context.Portions.FindAsync(idToUpdate);
            Assert.NotNull(updatedPortion);
        }
    }
}