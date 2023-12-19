using AutoMapper;
using Restaraunt.RestarauntSystem.BLL.Models.Order;
using Restaraunt.RestarauntSystem.DAL.Entities;

namespace Restaraunt.RestarauntSystem.BLL.Mapping
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
