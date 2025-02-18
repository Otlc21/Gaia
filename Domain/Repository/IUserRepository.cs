using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        Task<int> Count(User item);
        Task<User> Get(Guid id);
        Task<List<User>> Get(User item, int skip = 0, int take = 10);
        Task<Guid> Insert(User item);
        Task Update(User item);
        Task Delete(Guid id);
    }
}
