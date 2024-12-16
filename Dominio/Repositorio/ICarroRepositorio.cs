using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface ICarroRepositorio
    {
        Task<int> Count(Carro item);
        Task<Carro> Get(int id);
        Task<List<Carro>> Get(Carro item, int skip, int take);
        Task Insert(Carro item);
        Task Update(Carro item);
        Task Delete(int id);
    }
}
