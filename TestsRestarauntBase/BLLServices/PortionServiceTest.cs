using AutoMapper;
using Moq;
using RestarauntBLL.Services.Abstract;
using RestarauntBLL.Services;
using RestarauntDAL.Entities;
using RestarauntDAL.Repositories;
using RestarauntBLL.Models.Portion;

namespace TestsRestaraunt.BLLServices
{
    public class PortionServiceTests
    {
      
        private readonly Mock<IGenericRepository<Portion>> _mockPortionRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IPortionService _portionService;

        public PortionServiceTests()
        { 
            _mockPortionRepository = new Mock<IGenericRepository<Portion>>();
            _mockMapper = new Mock<IMapper>();
            _mockMapper.Setup(setup => setup.Map<PortionDto>(It.IsAny<Portion>()))
                .Returns((Portion sourcePortion) =>
                {
                    var mappedDto = new PortionDto
                    {
                        Id = sourcePortion.Id,
                        Weight = sourcePortion.Weight,
                        Price= sourcePortion.Price,
                        DishId = sourcePortion.DishId
                   
                    };
                    return mappedDto;
                });

            _portionService = new PortionService(
                _mockPortionRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllPortionAsync_ShouldReturnPortionDto()
        {
            // Arrange
            var portions = Portions();
            var portionsDto = _mockMapper.Object.Map<IEnumerable<PortionDto>>(portions);

            _mockPortionRepository.Setup(setup => setup.GetAllObjectAsync())
                .ReturnsAsync(portions); 

            // Act
            var result = await _portionService.GetAllPortionAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<PortionDto>>(result);
            Assert.Equal(portionsDto, result);
        }



        [Fact]
        public async Task UpdateDish_ShouldUpdatePortion()
        {
            // Arrange
            var portionId = 1;
            var dishDto = new PortionForDishDto
            {
                Price = 32,
                Weight= 32
            };
            var dish = new Portion { Id = portionId };

            _mockPortionRepository.Setup(setup => setup.GetByIdAsync(portionId)).ReturnsAsync(dish);
            _mockPortionRepository.Setup(setup => setup.UpdateAsync(It.IsAny<Portion>())).Verifiable();
            _mockPortionRepository.Setup(setup => setup.SaveAsync()).Returns(Task.CompletedTask).Verifiable();

            // Act
            await _portionService.UpdatePortionAsync(portionId, dishDto);

            // Assert
            _mockPortionRepository.Verify();
        }
        public static List<Portion> Portions()
        {
            return new List<Portion>
            {
              new Portion
              {
                 Id = 1,
                 Weight = 23,
                 Price= 232,
                 DishId = 1
              },
              new Portion
              {
                 Id = 2,
                 Weight = 23,
                 Price= 232,
                 DishId = 4

              },
              new Portion
              {
                 Id = 3,
                 Weight = 23,
                 Price= 232,
                 DishId = 1

              }
            };
        }
    }
}
