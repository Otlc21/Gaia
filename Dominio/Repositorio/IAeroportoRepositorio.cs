using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IAeroportoRepositorio
    {
        Task<int> Count(Aeroporto item);
        Task<Aeroporto> Get(int id);
        Task<List<Aeroporto>> Get(Aeroporto item, int skip, int take);
        Task Insert(Aeroporto item);
        Task Update(Aeroporto item);
        Task Delete(int id);
    }
}
