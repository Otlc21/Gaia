using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IAirlineRepository
    {
        Task<int> Count(Airline item);
        Task<Airline> Get(int id);
        Task<List<Airline>> Get(Airline item, int skip, int take);
        Task Insert(Airline item);
        Task Update(Airline item);
        Task Delete(int id);
    }
}
