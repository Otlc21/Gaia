using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Repository
{
    public class HotelRepository : IHotelRepository
    {
        public Task<int> Count(Hotel item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Hotel>> Get(Hotel item, int skip = 0, int take = 10)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Insert(Hotel item)
        {
            throw new NotImplementedException();
        }

        public Task Update(Hotel item)
        {
            throw new NotImplementedException();
        }
    }
}
