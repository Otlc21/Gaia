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
    public class MarkupService : IMarkupService
    {
        private readonly IMarkupRepository _repository;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public MarkupService(IMarkupRepository repository, IStringLocalizer<SharedResources> localizer)
        {
            _repository = repository;
            _localizer = localizer;

        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task<int> Count(Markup item)
        {
            return await _repository.Count(item);
        }

        public async Task<Markup> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<Markup>> Get(Markup item, int skip = 0, int take = 10)
        {
            return await _repository.Get(item, skip, take);
        }

        public async Task<Guid> Insert(Markup item)
        {
            return await _repository.Insert(item);
        }

        public async Task Update(Markup item)
        {
            await _repository.Update(item);
        }
    }
}
