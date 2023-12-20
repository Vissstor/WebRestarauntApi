using AutoMapper;
using RestarauntBLL.Models.Ingredient;
using RestarauntBLL.Services.Abstract;
using RestarauntDAL.Entities;
using RestarauntDAL.Repositories;

namespace RestarauntBLL.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IGenericRepository<Ingredient> _genericRepository;
        private readonly IMapper _mapper;
        public IngredientService(IGenericRepository<Ingredient> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<IngredientDto>> GetIngredientsAsync()
        {
            var ingredients = await _genericRepository.GetAllObjectAsync();
            return _mapper.Map<IEnumerable<IngredientDto>>(ingredients);
        }

        public async Task DeleteIngredient(long id)
        {
            var ingredient = await _genericRepository.GetByIdAsync(id)
                ?? throw new Exception(" Ingredient id is incorect."); ;
            _genericRepository.Delete(ingredient);
            await _genericRepository.SaveAsync();

        }
        public async Task CreateIngredient(IngredientCreateDto ingredient)
        {
            var ing = _mapper.Map<Ingredient>(ingredient);
            await _genericRepository.Create(ing);
            await _genericRepository.SaveAsync();
        }



    }
}
