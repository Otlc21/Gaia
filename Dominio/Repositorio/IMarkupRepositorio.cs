using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IMarkupRepositorio
    {
        Task<int> Count(Markup item);
        Task<Markup> Get(int id);
        Task<List<Markup>> Get(Markup item, int skip, int take);
        Task Insert(Markup item);
        Task Update(Markup item);
        Task Delete(int id);
    }
}
