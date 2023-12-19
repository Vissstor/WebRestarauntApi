using AutoMapper;
using Restaraunt.RestarauntSystem.BLL.Models.Order;
using Restaraunt.RestarauntSystem.BLL.Models.Portion;
using Restaraunt.RestarauntSystem.BLL.Services.Abstract;
using Restaraunt.RestarauntSystem.DAL;
using Restaraunt.RestarauntSystem.DAL.Entities;
using Restaraunt.RestarauntSystem.DAL.Repositories;

namespace Restaraunt.RestarauntSystem.BLL.Services
{
    public class PortionService : IPortionService
    {
        private readonly IGenericRepository<Portion> _genericRepository;
        private readonly IMapper _mapper;
        public PortionService(IGenericRepository<Portion> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PortionDto>> GetAllPortionAsync()
        {
            var portions = await _genericRepository.GetAllObjectAsync();
            return _mapper.Map<IEnumerable<PortionDto>>(portions);
        }

        public async Task UpdatePortionAsync(long id, PortionForDishDto orderToUpdate)
        {
            var por = await _genericRepository.GetByIdAsync(id)
                 ?? throw new Exception(" Order id is incorect.");
            por.Weight = orderToUpdate.Weight;
            por.Price= orderToUpdate.Price;
            await _genericRepository.UpdateAsync(por);
            await _genericRepository.SaveAsync();
        }
        //public async Task<IEnumerable<PortionDto>> GetPortionFilterAsync(int weihgt, decimal price)
        //{
        //    var portions = await _genericRepository.GetAfterFilterAsync(x => x.Weight == weihgt || x.Price == price);
        //    return _mapper.Map<IEnumerable<PortionDto>>(portions);
        //}
    }
}
