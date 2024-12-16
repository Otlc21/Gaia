using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IAereoRepositorio
    {
        Task<int> Count(Aereo item);
        Task<Aereo> Get(int id);
        Task<List<Aereo>> Get(Aereo item, int skip, int take);
        Task Insert(Aereo item);
        Task Update(Aereo item);
        Task Delete(int id);
    }
}
