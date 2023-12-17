using AutoMapper;
using Restaraunt.RestarauntSystem.BLL.Models.Dish;
using Restaraunt.RestarauntSystem.BLL.Models.Ingredient;
using Restaraunt.RestarauntSystem.BLL.Services.Abstract;
using Restaraunt.RestarauntSystem.DAL.Entities;
using Restaraunt.RestarauntSystem.DAL.Repositories;

namespace Restaraunt.RestarauntSystem.BLL.Services
{
    public class DishService : IDishService
    {
        private readonly IGenericRepository<Dish> _dishRepository;
        private readonly IGenericRepository<IngredientDish> _ingredientDishRepository;
        private IMapper _mapper;
        public DishService(IGenericRepository<Dish> genericRepository, IMapper mapper, IGenericRepository<IngredientDish> ingredientDishRepository)
        {
            _dishRepository = genericRepository;
            _ingredientDishRepository = ingredientDishRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DishDto>> GetAllDishiesAsync()
        {
            var dishies = await _dishRepository.GetAllInformationObjectAsync(x=>x.Portions);
            return _mapper.Map<IEnumerable<DishDto>>(dishies);
        }
        
        public async Task<DishDto> GetDishByIdAsync(long id)
        {
            var dis = await _dishRepository.GetByIdIncludeAsync(id,x=>x.Portions);
            return _mapper.Map<DishDto>(dis);
        }
        public async Task CreateDishAsync(DishCreateDto dish)
        {
            var dishEntity = _mapper.Map<Dish>(dish);
            await _dishRepository.Create(dishEntity);
            await _dishRepository.SaveAsync();
            if (dish.IngredientsId is not null && dish.IngredientsId.Any())
            {
                var dishIngredients = dish.IngredientsId
                    .Select(ingredientId => new IngredientDish { DishId = dishEntity.Id, IngredientId = ingredientId })
                    .ToList();

                await _ingredientDishRepository.CreateArange(dishIngredients);
                await _ingredientDishRepository.SaveAsync();
            }
        }

        public async Task DeleteDishAsync(long id)
        {
            var dishEntity= await _dishRepository.GetByIdAsync(id);
            _dishRepository.Delete(dishEntity);
            await _dishRepository.SaveAsync();
        }
    }
}
