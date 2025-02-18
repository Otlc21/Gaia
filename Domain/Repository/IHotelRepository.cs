using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IHotelRepository
    {
        Task<int> Count(Hotel item);
        Task<Hotel> Get(Guid id);
        Task<List<Hotel>> Get(Hotel item, int skip = 0, int take = 10);
        Task<Guid> Insert(Hotel item);
        Task Update(Hotel item);
        Task Delete(Guid id);
    }
}
