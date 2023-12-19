using AutoMapper;
using Restaraunt.RestarauntSystem.BLL.Models.Dish;
using Restaraunt.RestarauntSystem.BLL.Models.Order;
using Restaraunt.RestarauntSystem.BLL.Models.Portion;
using Restaraunt.RestarauntSystem.DAL.Entities;

namespace Restaraunt.RestarauntSystem.BLL.Mapping
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishDto>()
            .ForMember(dest => dest.IngredientsId, opt => opt.MapFrom(src => src.IngredientsDishes.Select(ing => ing.IngredientId)))
            .ForMember(dest => dest.Portions, opt => opt.MapFrom(src => src.Portions.Select(p => new PortionForDishDto
            {
                Weight = p.Weight,
                Price = p.Price
            }).ToList()));

            CreateMap<DishCreateDto, Dish>();
        }
    }
}

