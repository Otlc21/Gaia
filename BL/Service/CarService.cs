using Domain.Entity;
using Domain.Repository;
using Domain.Resource;
using Domain.Service;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public CarService(ICarRepository repository, IStringLocalizer<SharedResources> localizer)
        {
            _repository = repository;
            _localizer = localizer;
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task<int> Count(Car item)
        {
            return await _repository.Count(item);
        }

        public async Task<Car> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<Car>> Get(Car item, int skip = 0, int take = 10)
        {
            return await _repository.Get(item, skip, take);
        }

        public async Task<Guid> Insert(Car item)
        {
            return await _repository.Insert(item);
        }

        public async Task Update(Car item)
        {
            await _repository.Update(item);
        }

        public Task<List<Car>> GetTrending()
        {
            throw new NotImplementedException();
        }
    }
}
