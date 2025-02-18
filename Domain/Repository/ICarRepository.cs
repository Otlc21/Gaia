using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ICarRepository
    {
        Task<int> Count(Car item);
        Task<Car> Get(Guid id);
        Task<List<Car>> Get(Car item, int skip = 0, int take = 10);
        Task<Guid> Insert(Car item);
        Task Update(Car item);
        Task Delete(Guid id);
    }
}
