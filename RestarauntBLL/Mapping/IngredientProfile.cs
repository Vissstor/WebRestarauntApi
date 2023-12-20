using AutoMapper;
using RestarauntBLL.Models.Ingredient;
using RestarauntDAL.Entities;

namespace RestarauntBLL.Mapping
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientCreateDto, Ingredient>();
            CreateMap<Ingredient, IngredientCreateDto>();
        }
    }
}
