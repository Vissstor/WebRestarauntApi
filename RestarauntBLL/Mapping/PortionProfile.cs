using AutoMapper;
using RestarauntBLL.Models.Portion;
using RestarauntDAL.Entities;

namespace RestarauntBLL.Mapping
{
    public class PortionProfilem : Profile
    {
        public PortionProfilem()
        {
            CreateMap<PortionForDishDto, Portion>();
            CreateMap<Portion, PortionDto>();
            CreateMap<Portion, PortionForDishDto>();
        }
    }
}

