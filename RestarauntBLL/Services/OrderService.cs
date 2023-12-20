using AutoMapper;
using RestarauntBLL.Models.Order;
using RestarauntBLL.Services.Abstract;
using RestarauntDAL;
using RestarauntDAL.Entities;
using RestarauntDAL.Repositories;

namespace RestarauntBLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;
        private readonly IGenericRepository<Portion> _portionRepository;
        public OrderService(IGenericRepository<Order> orderRepository, IMapper mapper,
            IGenericRepository<OrderDetail> orderDetailRepository
            , IGenericRepository<Portion> portionRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderDetailRepository = orderDetailRepository;
            _portionRepository = portionRepository;
        }
        public async Task<IEnumerable<OrderDto>> GetAllOrderAsync()
        {
            var orderEntities = await _orderRepository.GetAllInformationObjectAsync(x => x.OrdersDetail);
            var order = _mapper.Map<IEnumerable<OrderDto>>(orderEntities);
            foreach (var item in order)
            {
                var totalPrice = 0m;
                foreach (var item1 in item.PortionsDto)
                {
                    var portionPrice = await _portionRepository.GetByIdAsync(item1)
                        ?? throw new Exception(" Portion id is incorect."); ;
                    totalPrice += portionPrice.Price;
                }
                item.TotalPrice = totalPrice;
            }
            return order;
        }


        public async Task DeleteOrderAsync(long id)
        {
            var order = await _orderRepository.GetByIdAsync(id)
                 ?? throw new Exception(" Order id is incorect."); ;
            _orderRepository.Delete(order);
            await _orderRepository.SaveAsync();
        }
        public async Task CreateOrderAsync(NewOrderDto newOrder)
        {

            var order = new Order
            {
                DateOrder = DateTime.Now,
                Status = StatusOrder.Expected,
                TableNumber = newOrder.TableNumber
            };

            await _orderRepository.Create(order);
            await _orderRepository.SaveAsync();
            var orderDetails = newOrder.PortionsId
                   .Select(dto => new OrderDetail
                   {
                     OrderId = order.Id,
                     PortionId = dto,
        
                   })
                    .ToList();

            await _orderDetailRepository.CreateArange(orderDetails);
            await _orderDetailRepository.SaveAsync();
        }
        public async Task<IEnumerable<OrderDto>> GetOrderByStatusOrderAsync(StatusOrder statusOrder)
        {
            return _mapper.Map<IEnumerable<OrderDto>>(await _orderRepository.GetAfterFilterAsync(x => x.Status == statusOrder));

        }

        public async Task<OrderDto> GetOrderByIdAsync(long id)
        {
            var order = await _orderRepository.GetByIdIncludeAsync(x => x.Id == id, x => x.OrdersDetail)
                 ?? throw new Exception(" Order id is incorect.");

            var orderDto = _mapper.Map<OrderDto>(order);
            var totalPrice = 0m;
            foreach (var item in orderDto.PortionsDto)
            {
                var portionPrice = await _portionRepository.GetByIdAsync(item)
                     ?? throw new Exception(" Portion id is incorect.");
                totalPrice += portionPrice.Price;
            }
            orderDto.TotalPrice = totalPrice;

            return orderDto;
        }
        public async Task UpdateOrderAsync(long id, UpdateOrderDto orderToUpdate)
        {
            var order = await _orderRepository.GetByIdAsync(id) ?? throw new Exception("Order id is incorrect.");

            if (!Enum.IsDefined(typeof(StatusOrder), orderToUpdate.StatusOrder))
            {
                throw new Exception("Invalid StatusOrder value");
            }

            order.Status = orderToUpdate.StatusOrder;
            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveAsync();
        }
    }
}
