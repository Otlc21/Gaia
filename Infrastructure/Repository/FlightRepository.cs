using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Repository
{
    public class FlightRepository : IFlightRepository
    {
        public Task<int> Count(Flight item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Flight> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Flight>> Get(Flight item, int skip = 0, int take = 10)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Insert(Flight item)
        {
            throw new NotImplementedException();
        }

        public Task Update(Flight item)
        {
            throw new NotImplementedException();
        }
    }
}
