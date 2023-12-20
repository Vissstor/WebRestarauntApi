using AutoMapper;
using RestarauntBLL.Models.Dish;
using RestarauntBLL.Models.Portion;
using RestarauntDAL.Entities;

namespace RestarauntBLL.Mapping
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

