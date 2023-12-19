using AutoMapper;
using Restaraunt.RestarauntSystem.BLL.Models.Dish;
using Restaraunt.RestarauntSystem.BLL.Models.Ingredient;
using Restaraunt.RestarauntSystem.BLL.Models.Order;
using Restaraunt.RestarauntSystem.BLL.Models.Portion;
using Restaraunt.RestarauntSystem.BLL.Services.Abstract;
using Restaraunt.RestarauntSystem.DAL.Entities;
using Restaraunt.RestarauntSystem.DAL.Repositories;
using System.Runtime.InteropServices;

namespace Restaraunt.RestarauntSystem.BLL.Services
{
    public class DishService : IDishService
    {
        private readonly IGenericRepository<Dish> _dishRepository;
        private readonly IGenericRepository<IngredientDish> _ingredientDishRepository;
        private readonly IGenericRepository<Portion> _portionDishRepository;


        private IMapper _mapper;
        public DishService(IGenericRepository<Dish> genericRepository, IMapper mapper,
            IGenericRepository<IngredientDish> ingredientDishRepository,
            IGenericRepository<Portion> portionDishRepository, IGenericRepository<Ingredient> ingredientRepository)
        {
            _dishRepository = genericRepository;
            _ingredientDishRepository = ingredientDishRepository;
            _portionDishRepository = portionDishRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DishDto>> GetAllDishiesAsync()
        {
            var dishEntities = await _dishRepository.GetAllInformationObjectAsync(x => x.IngredientsDishes, x => x.Portions);

            return _mapper.Map<IEnumerable<DishDto>>(dishEntities);
        }

        public async Task<DishDto> GetDishByIdAsync(long id)
        {
            var dis = await _dishRepository.GetByIdIncludeAsync(x => x.Id == id, x => x.Portions,x=>x.IngredientsDishes)
                ?? throw new Exception(" Dish id is incorect.");
            return _mapper.Map<DishDto>(dis);
        }
        public async Task CreateDishAsync(DishCreateDto dish)
        {
            var dishEntity = _mapper.Map<Dish>(dish);
            await _dishRepository.Create(dishEntity);
            await _dishRepository.SaveAsync();
            if (dish.IngredientsId is null || dish.Portions is null )
            {
                throw new Exception("List id is empty");
            }

            var dishIngredients = dish.IngredientsId
                    .Select(ingredientId => new IngredientDish { DishId = dishEntity.Id, IngredientId = ingredientId })
                    .ToList();

            await _ingredientDishRepository.CreateArange(dishIngredients);
            await _ingredientDishRepository.SaveAsync();
            var portion = _mapper.Map<IEnumerable<Portion>>(dish.Portions);
            foreach (var item in portion)
            {
                item.DishId = dishEntity.Id;
                await _portionDishRepository.Create(item);
            }

            await _portionDishRepository.SaveAsync();
        }

        public async Task DeleteDishAsync(long id)
        {
            var dishEntity = await _dishRepository.GetByIdAsync(id)
                 ?? throw new Exception(" Dish id is incorect.");
            _dishRepository.Delete(dishEntity);
            await _dishRepository.SaveAsync();
        }
        public async Task UpdateDish(long id, UpdateDishDto dishDto)
        {
            var dish = await _dishRepository.GetByIdAsync(id) 
                ?? throw new Exception("Incorect dish id.");
            dish.Description = dishDto.Description;
            dish.Name=dishDto.Name;
            await _dishRepository.UpdateAsync(dish);
            await _dishRepository.SaveAsync();
        }
    }
}
