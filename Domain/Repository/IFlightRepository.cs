using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IFlightRepository
    {
        Task<int> Count(Flight item);
        Task<Flight> Get(Guid id);
        Task<List<Flight>> Get(Flight item, int skip = 0, int take = 10);
        Task<Guid> Insert(Flight item);
        Task Update(Flight item);
        Task Delete(Guid id);
    }
}
