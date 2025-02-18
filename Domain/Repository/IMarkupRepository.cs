using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IMarkupRepository
    {
        Task<int> Count(Markup item);
        Task<Markup> Get(Guid id);
        Task<List<Markup>> Get(Markup item, int skip = 0, int take = 10);
        Task<Guid> Insert(Markup item);
        Task Update(Markup item);
        Task Delete(Guid id);
    }
}
