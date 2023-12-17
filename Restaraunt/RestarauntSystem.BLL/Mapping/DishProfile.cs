using AutoMapper;
using Restaraunt.RestarauntSystem.BLL.Models.Dish;
using Restaraunt.RestarauntSystem.DAL.Entities;

namespace Restaraunt.RestarauntSystem.BLL.Mapping
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishDto>();
            CreateMap<DishCreateDto, Dish>();
            
        }
    }
}
