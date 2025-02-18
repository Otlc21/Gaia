using Domain.Entity;
using Domain.Repository;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<int> Count(User item)
        {            
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> Get(User item, int skip = 0, int take = 10)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Insert(User item)
        {
            throw new NotImplementedException();
        }

        public Task Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
