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
        Task<Markup> Get(int id);
        Task<List<Markup>> Get(Markup item, int skip, int take);
        Task Insert(Markup item);
        Task Update(Markup item);
        Task Delete(int id);
    }
}
