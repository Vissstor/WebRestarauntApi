using AutoMapper;
using RestarauntBLL.Models.Order;
using RestarauntDAL.Entities;

namespace RestarauntBLL.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
                            .ForMember(dest => dest.PortionsDto, opt => opt.MapFrom(src => src.OrdersDetail.Select(ing => ing.PortionId)));
            CreateMap<Order, UpdateOrderDto>();

        }
    }

}
