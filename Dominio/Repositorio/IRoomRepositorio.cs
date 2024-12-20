using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IRoomRepositorio
    {
        Task<int> Count(Room item);
        Task<Room> Get(int id);
        Task<List<Room>> Get(Room item, int skip, int take);
        Task Insert(Room item);
        Task Update(Room item);
        Task Delete(int id);
    }
}
