using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public interface ICompanhiaAereaServico
    {
        Task<int> Count(CompanhiaAerea item);
        Task<CompanhiaAerea> Get(int id);
        Task<List<CompanhiaAerea>> Get(CompanhiaAerea item, int skip, int take);
        Task Insert(CompanhiaAerea item);
        Task Update(CompanhiaAerea item);
        Task Delete(int id);
    }
}
