using AutoMapper;
using Restaraunt.RestarauntSystem.BLL.Models.Portion;
using Restaraunt.RestarauntSystem.DAL.Entities;

namespace Restaraunt.RestarauntSystem.BLL.Mapping
{
    public class PortionProfilem : Profile
    {
        public PortionProfilem()
        {
            CreateMap<PortionCreateDto, Portion>();
            CreateMap<Portion, PortionDto>();
        }
    }
}
