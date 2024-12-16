using Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public interface IHotelServico
    {
        Task<int> Count(Hotel item);
        Task<Hotel> Get(int id);
        Task<List<Hotel>> Get(Hotel item, int skip, int take);
        Task Insert(Hotel item);
        Task Update(Hotel item);
        Task Delete(int id);
    }
}
