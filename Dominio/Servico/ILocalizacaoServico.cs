using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public interface ILocalizacaoServico
    {
        Task<int> Count(Localizacao item);
        Task<Localizacao> Get(int id);
        Task<List<Localizacao>> Get(Localizacao item, int skip, int take);
        Task Insert(Localizacao item);
        Task Update(Localizacao item);
        Task Delete(int id);
    }
}
