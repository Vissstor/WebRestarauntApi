using AutoMapper;
using RestarauntBLL.Models.Dish;
using RestarauntBLL.Services.Abstract;
using RestarauntDAL.Entities;
using RestarauntDAL.Repositories;
using RestarauntDAL.Specifications;

namespace RestarauntBLL.Services
{
    public class DishService : IDishService
    {
        private readonly IGenericRepository<Dish> _dishRepository;
        private readonly IGenericRepository<IngredientDish> _ingredientDishRepository;
        private readonly IGenericRepository<Portion> _portionDishRepository;


        private IMapper _mapper;
        public DishService(IGenericRepository<Dish> genericRepository, IMapper mapper,
            IGenericRepository<IngredientDish> ingredientDishRepository,
            IGenericRepository<Portion> portionDishRepository)
        {
            _dishRepository = genericRepository;
            _ingredientDishRepository = ingredientDishRepository;
            _portionDishRepository = portionDishRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DishDto>> GetAllDishiesAsync()
        {
            var dishEntities = await _dishRepository.GetObjectAsync(new DishIncludeSpecification());

            return _mapper.Map<IEnumerable<DishDto>>(dishEntities);
        }

        public async Task<DishDto> GetDishByIdAsync(long id)
        {
            var dis = await _dishRepository.GetByIdIncludeAsync(new DishByIdSpecification(id))
                ?? throw new Exception(" Dish id is incorect.");
            return _mapper.Map<DishDto>(dis);
        }
        public async Task CreateDishAsync(DishCreateDto dish)
        {
            var dishEntity = _mapper.Map<Dish>(dish);
            await _dishRepository.Create(dishEntity);
            await _dishRepository.SaveAsync();
            if (dish.IngredientsId is null || dish.Portions is null)
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
      
    }
}
