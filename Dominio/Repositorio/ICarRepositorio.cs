using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface ICarRepositorio
    {
        Task<int> Count(Car item);
        Task<Car> Get(int id);
        Task<List<Car>> Get(Car item, int skip, int take);
        Task Insert(Car item);
        Task Update(Car item);
        Task Delete(int id);
    }
}
