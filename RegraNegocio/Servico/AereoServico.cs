using Dominio.Entidade;
using Dominio.Repositorio;
using Dominio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegraNegocio.Servico
{
    public class AereoServico : IAereoServico
    {
        private readonly IAereoRepositorio _repositorio;

        public AereoServico(IAereoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task<int> Count(Aereo item)
        {
            return await _repositorio.Count(item);
        }

        public async Task<Aereo> Get(int id)
        {
            return await _repositorio.Get(id);
        }

        public async Task<List<Aereo>> Get(Aereo item, int skip, int take)
        {
            return await _repositorio.Get(item, skip, take);
        }

        public async Task Insert(Aereo item)
        {
            await _repositorio.Insert(item);
        }

        public async Task Update(Aereo item)
        {
            await _repositorio.Update(item);
        }
    }
}
