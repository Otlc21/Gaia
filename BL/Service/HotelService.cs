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
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _repository;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public HotelService(IHotelRepository repository, IStringLocalizer<SharedResources> localizer)
        {
            _repository = repository;
            _localizer = localizer;

        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task<int> Count(Hotel item)
        {
            return await _repository.Count(item);
        }

        public async Task<Hotel> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<Hotel>> Get(Hotel item, int skip = 0, int take = 10)
        {
            return await _repository.Get(item, skip, take);
        }
        public async Task<Guid> Insert(Hotel item)
        {
            return await _repository.Insert(item);
        }

        public async Task Update(Hotel item)
        {
            await _repository.Update(item);
        }
        
        public async Task<List<Hotel>> GetTrending()
        {
            return await _repository.Get(new Hotel(), 0, 5);
        }
    }
}
