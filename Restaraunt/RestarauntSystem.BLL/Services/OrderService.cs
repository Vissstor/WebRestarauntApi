using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Converters;
using Restaraunt.RestarauntSystem.BLL.Models.Dish;
using Restaraunt.RestarauntSystem.BLL.Models.Order;
using Restaraunt.RestarauntSystem.BLL.Services.Abstract;
using Restaraunt.RestarauntSystem.DAL;
using Restaraunt.RestarauntSystem.DAL.Entities;
using Restaraunt.RestarauntSystem.DAL.Repositories;

namespace Restaraunt.RestarauntSystem.BLL.Services
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
            var order=_mapper.Map<IEnumerable<OrderDto>>(orderEntities);
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

            var orderDetail = _mapper.Map<IEnumerable<OrderDetail>>(newOrder.OrderDetailDto);
            foreach (var item in orderDetail)
            {
                item.OrderId = order.Id;
            }
            await _orderDetailRepository.CreateArange(orderDetail);
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
            var order = await _orderRepository.GetByIdAsync(id)
                 ?? throw new Exception(" Order id is incorect.");
            order.Status = (StatusOrder)orderToUpdate.StatusOrder;
            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveAsync();
        }
    }
}
