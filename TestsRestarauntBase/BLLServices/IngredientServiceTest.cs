using AutoMapper;
using Moq;
using RestarauntBLL.Services.Abstract;
using RestarauntBLL.Services;
using RestarauntDAL.Entities;
using RestarauntDAL.Repositories;
using RestarauntBLL.Models.Portion;
using RestarauntBLL.Models.Dish;
using RestarauntBLL.Models.Ingredient;

namespace TestsRestaraunt.BLLServices
{
    public class IngredientServiceTest
    {

        private readonly Mock<IGenericRepository<Ingredient>> _mockIngredientRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IIngredientService _ingredientService;

        public IngredientServiceTest()
        {
            _mockIngredientRepository = new Mock<IGenericRepository<Ingredient>>();
            _mockMapper = new Mock<IMapper>();

            _ingredientService = new IngredientService(
                _mockIngredientRepository.Object, _mockMapper.Object);
        }
        [Fact]
        public async Task GetAllIngredientAsync_ShouldReturnIngredientDto()
        {
            // Arrange
            var ingredients = GetIngredients();
            var ingredientDtos = _mockMapper.Object.Map<IEnumerable<IngredientDto>>(ingredients);

            _mockIngredientRepository.Setup(setup => setup.GetAllObjectAsync())
                .ReturnsAsync(ingredients);
            _mockMapper.Setup(setup => setup.Map<IEnumerable<IngredientDto>>(It.IsAny<IEnumerable<Ingredient>>())).Returns(ingredientDtos);

            // Act
            var result = await _ingredientService.GetIngredientsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<IngredientDto>>(result);
            Assert.Equal(ingredientDtos, result);
        }

        [Fact]
        public async Task DeleteIngredientAsync_ShouldDeleteIngredient()
        {
            // Arrange
            var ingredientId = 1;
            var ingredient = new Ingredient { Id = ingredientId };

            // Mock repository setup
            _mockIngredientRepository.Setup(setup => setup.GetByIdAsync(ingredientId)).ReturnsAsync(ingredient);
            _mockIngredientRepository.Setup(setup => setup.Delete(It.IsAny<Ingredient>())).Verifiable();
            _mockIngredientRepository.Setup(setup => setup.SaveAsync()).Returns(Task.CompletedTask).Verifiable();

            // Act
            await _ingredientService.DeleteIngredient(ingredientId);

            // Assert
            _mockIngredientRepository.Verify();
        }

        [Fact]
        public async Task CreateIngredient_ShouldCreateIngredient()
        {
            
            var ingredient = new Ingredient
            {
               Name = "name",
            };
            var ingredient1 = _mockMapper.Object.Map<IngredientCreateDto>(ingredient);

            _mockIngredientRepository.Setup(setup => setup.Create(ingredient));
            _mockIngredientRepository.Setup(setup => setup.SaveAsync()).Returns(Task.CompletedTask).Verifiable();
            _mockMapper.Setup(m => m.Map<IngredientCreateDto>(ingredient)).Returns(ingredient1);
            // Act
            await _ingredientService.CreateIngredient(ingredient1);

            // Assert
            _mockIngredientRepository.Verify();
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
    }
}

