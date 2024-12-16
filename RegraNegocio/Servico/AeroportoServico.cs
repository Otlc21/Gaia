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
    public class AeroportoServico : IAeroportoServico
    {
        private readonly IAeroportoRepositorio _repositorio;

        public AeroportoServico(IAeroportoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task<int> Count(Aeroporto item)
        {
            return await _repositorio.Count(item);
        }

        public async Task<Aeroporto> Get(int id)
        {
            return await _repositorio.Get(id);
        }

        public async Task<List<Aeroporto>> Get(Aeroporto item, int skip, int take)
        {
            return await _repositorio.Get(item, skip, take);
        }

        public async Task Insert(Aeroporto item)
        {
            await _repositorio.Insert(item);
        }

        public async Task Update(Aeroporto item)
        {
            await _repositorio.Update(item);
        }
    }
}
