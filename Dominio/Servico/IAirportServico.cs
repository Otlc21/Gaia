using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public interface IAirportServico
    {
        Task<int> Count(Airport item);
        Task<Airport> Get(int id);
        Task<List<Airport>> Get(Airport item, int skip, int take);
        Task Insert(Airport item);
        Task Update(Airport item);
        Task Delete(int id);
    }
}
