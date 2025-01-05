using Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repository
{
    public interface IFlightRepository
    {
        Task<int> Count(Flight item);
        Task<Flight> Get(int id);
        Task<List<Flight>> Get(Flight item, int skip, int take);
        Task Insert(Flight item);
        Task Update(Flight item);
        Task Delete(int id);
    }
}
