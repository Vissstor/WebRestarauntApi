using AutoMapper;
using Moq;
using RestarauntBLL.Models.Dish;
using RestarauntBLL.Models.Portion;
using RestarauntBLL.Services;
using RestarauntBLL.Services.Abstract;
using RestarauntDAL.Entities;
using RestarauntDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestsRestaraunt.BLLServices
{
    public class DishServiceTests
    {
        private readonly Mock<IGenericRepository<Dish>> _mockDishRepository;
        private readonly Mock<IGenericRepository<IngredientDish>> _mockIngredientDishRepository;
        private readonly Mock<IGenericRepository<Portion>> _mockPortionRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IDishService _dishService;

        public DishServiceTests()
        {
            _mockDishRepository = new Mock<IGenericRepository<Dish>>();
            _mockIngredientDishRepository = new Mock<IGenericRepository<IngredientDish>>();
            _mockPortionRepository = new Mock<IGenericRepository<Portion>>();
            _mockMapper = new Mock<IMapper>();
    

            _dishService = new DishService(
                _mockDishRepository.Object,
                _mockMapper.Object,
                _mockIngredientDishRepository.Object,
                _mockPortionRepository.Object);
        }

        [Fact]
        public async Task GetAllDishesAsync_ShouldReturnDishDtos()
        {
            // Arrange
            var dishes = GetDishies();
            var dishDtos = _mockMapper.Object.Map<IEnumerable<DishDto>>(dishes);

            _mockDishRepository.Setup(setup => setup.GetAllInformationObjectAsync(It.IsAny<Expression<Func<Dish, object>>[]>()))
                .ReturnsAsync(dishes);
            _mockMapper.Setup(setup => setup.Map<IEnumerable<DishDto>>(It.IsAny<IEnumerable<Dish>>())).Returns(dishDtos);

            // Act
            var result = await _dishService.GetAllDishiesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<DishDto>>(result);
            Assert.Equal(dishDtos, result);
        }


        [Fact]
        public async Task GetDishByIdAsync_ShouldReturnDishDto()
        {
            var dishId = 1;
            var dish = new Dish { Id = dishId };
            var dishDto = new DishDto { Id = dishId };
            _mockDishRepository.Setup(r => r.GetByIdIncludeAsync(It.IsAny<Expression<Func<Dish, bool>>>(),
                It.IsAny<Expression<Func<Dish, object>>[]>()))
                .ReturnsAsync(dish);
            _mockMapper.Setup(m => m.Map<DishDto>(dish)).Returns(dishDto);

            var result = await _dishService.GetDishByIdAsync(dishId);

            Assert.NotNull(result);
            Assert.IsType<DishDto>(result);
            Assert.Equal(dishDto, result);
        }

        

        [Fact]
        public async Task DeleteDishAsync_ShouldDeleteDish()
        {
            // Arrange
            var dishId = 1;
            var dish = new Dish { Id = dishId };

            // Mock repository setup
            _mockDishRepository.Setup(r => r.GetByIdAsync(dishId)).ReturnsAsync(dish);
            _mockDishRepository.Setup(setup => setup.Delete(It.IsAny<Dish>())).Verifiable();
            _mockDishRepository.Setup(setup => setup.SaveAsync()).Returns(Task.CompletedTask).Verifiable();

            // Act
            await _dishService.DeleteDishAsync(dishId);

            // Assert
            _mockDishRepository.Verify();
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

