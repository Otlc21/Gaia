using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Repository
{
    public class CarRepository : ICarRepository
    {
        public Task<int> Count(Car item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Car> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Car>> Get(Car item, int skip = 0, int take = 10)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Insert(Car item)
        {
            throw new NotImplementedException();
        }

        public Task Update(Car item)
        {
            throw new NotImplementedException();
        }
    }
}
