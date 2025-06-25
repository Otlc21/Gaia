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
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository _repository;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public AirportService(IAirportRepository repository, IStringLocalizer<SharedResources> localizer)
        {
            _repository = repository;
            _localizer = localizer;
        }

        public async Task<List<AirportName>> Get(string text, string culture, int skip = 0, int take = 10)
        {
            return await _repository.Get(text, culture, skip, take);
        }

    }
}
