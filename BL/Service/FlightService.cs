﻿using Domain.Entity;
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
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _repository;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public FlightService(IFlightRepository repository, IStringLocalizer<SharedResources> localizer)
        {
            _repository = repository;
            _localizer = localizer;

        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task<int> Count(Flight item)
        {
            return await _repository.Count(item);
        }

        public async Task<Flight> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<Flight>> Get(Flight item, int skip = 0, int take = 10)
        {
            return await _repository.Get(item, skip, take);
        }

        public async Task<Guid> Insert(Flight item)
        {
            return await _repository.Insert(item);
        }

        public async Task Update(Flight item)
        {
            await _repository.Update(item);
        }

        public async Task<List<Flight>> GetTrending()
        {
            return await _repository.Get(new Flight(), 0, 5);
        }
    }
}
