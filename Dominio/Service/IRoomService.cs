using Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Service
{
    public interface IRoomService
    {
        Task<int> Count(Room item);
        Task<Room> Get(int id);
        Task<List<Room>> Get(Room item, int skip, int take);
        Task Insert(Room item);
        Task Update(Room item);
        Task Delete(int id);
    }
}
