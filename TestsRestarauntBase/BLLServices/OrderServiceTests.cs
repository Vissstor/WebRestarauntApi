using AutoMapper;
using Moq;
using RestarauntBLL.Models.Order;
using RestarauntBLL.Services.Abstract;
using RestarauntBLL.Services;
using RestarauntDAL.Entities;
using RestarauntDAL.Repositories;
using System.Linq.Expressions;
using RestarauntDAL;

namespace TestsRestaraunt.BLLServices
{
    public class OrderServiceTests
    {
        private readonly Mock<IGenericRepository<Order>> _mockOrderRepository;
        private readonly Mock<IGenericRepository<OrderDetail>> _mockOrderDetailRepository;
        private readonly Mock<IGenericRepository<Portion>> _mockPortionRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IOrderService _orderService;

        public OrderServiceTests()
        {
            _mockOrderRepository = new Mock<IGenericRepository<Order>>();
            _mockOrderDetailRepository = new Mock<IGenericRepository<OrderDetail>>();
            _mockPortionRepository = new Mock<IGenericRepository<Portion>>();
            _mockMapper = new Mock<IMapper>();
           

            _orderService = new OrderService(_mockOrderRepository.Object, _mockMapper.Object,
             _mockOrderDetailRepository.Object,_mockPortionRepository.Object);
        }
        [Fact]
        public async Task GetAllOrderAsync_ShouldReturnOrderDtos()
        {
            // Arrange
            var orders = GetOrders();
            var orderDtos = _mockMapper.Object.Map<IEnumerable<OrderDto>>(orders);

            _mockOrderRepository.Setup(setup => setup.GetAllInformationObjectAsync(It.IsAny<Expression<Func<Order, object>>>()))
                .ReturnsAsync(orders);

            // Act
            var result = await _orderService.GetAllOrderAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<OrderDto>>(result);
            Assert.Equal(orderDtos, result);
        }

        [Fact]
        public async Task DeleteOrderAsync_ShouldDeleteOrder()
        {
            // Arrange
            var orderId = 1;
            var order = new Order { Id = orderId };

            _mockOrderRepository.Setup(setup => setup.GetByIdAsync(orderId)).ReturnsAsync(order);
            _mockOrderRepository.Setup(setup => setup.Delete(It.IsAny<Order>())).Verifiable();
            _mockOrderRepository.Setup(setup => setup.SaveAsync()).Returns(Task.CompletedTask).Verifiable();

            // Act
            await _orderService.DeleteOrderAsync(orderId);

            // Assert
            _mockOrderRepository.Verify();
        }

        [Fact]
        public async Task CreateOrderAsync_ShouldCreateOrder()
        {
            // Arrange
            var newOrderDto = new NewOrderDto
            {
                PortionsId = new List<long> { 1, 2, 3 },
                TableNumber = 42 
            };

            _mockMapper.Setup(m => m.Map<Order>(It.IsAny<NewOrderDto>())).Returns(new Order());
            _mockOrderRepository.Setup(repo => repo.Create(It.IsAny<Order>())).Verifiable();
            _mockOrderRepository.Setup(setup => setup.SaveAsync()).Returns(Task.CompletedTask).Verifiable();
            _mockOrderDetailRepository.Setup(repo => repo.CreateArange(It.IsAny<IEnumerable<OrderDetail>>())).Verifiable();
            _mockOrderDetailRepository.Setup(setup => setup.SaveAsync()).Returns(Task.CompletedTask).Verifiable();

            // Act
            await _orderService.CreateOrderAsync(newOrderDto);

            // Assert
            _mockOrderRepository.Verify();
            _mockOrderDetailRepository.Verify();
        }
        [Fact]
        public async Task UpdateOrderAsync_ShouldUpdateOrder()
        {
            // Arrange
            var orderId = 1;
            var updateOrderDto = new UpdateOrderDto
            {
               
            };
            var order = new Order { Id = orderId };

            _mockOrderRepository.Setup(setup => setup.GetByIdAsync(orderId)).ReturnsAsync(order);
            _mockOrderRepository.Setup(setup => setup.UpdateAsync(It.IsAny<Order>())).Verifiable();
            _mockOrderRepository.Setup(setup => setup.SaveAsync()).Returns(Task.CompletedTask).Verifiable();

            // Act
            await _orderService.UpdateOrderAsync(orderId, updateOrderDto);

            // Assert
            _mockOrderRepository.Verify();
        }
       
        [Fact]
        public async Task GetOrderByStatusOrderAsync_ShouldReturnOrderDtos()
        {
            // Arrange
            var statusOrder = StatusOrder.Expected;
            var orders = GetOrders().Where(o => o.Status == statusOrder);
            var orderDtos = _mockMapper.Object.Map<IEnumerable<OrderDto>>(orders);

            _mockOrderRepository.Setup(setup => setup.GetAfterFilterAsync(It.IsAny<Expression<Func<Order, bool>>>()))
                .ReturnsAsync(orders);

            // Act
            var result = await _orderService.GetOrderByStatusOrderAsync(statusOrder);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<OrderDto>>(result);
            Assert.Equal(orderDtos, result);
        }

        public static List<Order> GetOrders()
        {
            return new List<Order>
        {
          new Order
          {
             Id = 1,
             DateOrder = DateTime.Now,
             Status = StatusOrder.Expected,
             TableNumber = 1,
             OrdersDetail = new List<OrderDetail>
             {
                 new OrderDetail { OrderId = 2, PortionId = 1 },
                 new OrderDetail { OrderId = 1, PortionId = 2 }
             }
          },
          new Order
          {
             Id = 2,
             DateOrder = DateTime.Now.AddDays(-1),
             Status = StatusOrder.Completed,
             TableNumber = 2,
             OrdersDetail = new List<OrderDetail>
             {
                 new OrderDetail { OrderId  = 3, PortionId = 3 }
             }
          }
          
        };
        }
    }
}
