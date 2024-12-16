using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IQuartoRepositorio
    {
        Task<int> Count(Quarto item);
        Task<Quarto> Get(int id);
        Task<List<Quarto>> Get(Quarto item, int skip, int take);
        Task Insert(Quarto item);
        Task Update(Quarto item);
        Task Delete(int id);
    }
}
