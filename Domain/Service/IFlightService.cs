using Domain.Entity;
using Domain.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public interface IFlightService
    {

        Task<int> Count(Flight item);
        Task<Flight> Get(Guid id);
        Task<List<Flight>> GetTrending();
        Task<List<Flight>> Get(Flight item, int skip = 0, int take = 10);
        Task<Guid> Insert(Flight item);
        Task Update(Flight item);
        Task Delete(Guid id);
    }
}
