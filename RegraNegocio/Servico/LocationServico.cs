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
    public class LocationServico : ILocationServico
    {
        private readonly ILocationRepositorio _repositorio;

        public LocationServico(ILocationRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task<int> Count(Location item)
        {
            return await _repositorio.Count(item);
        }

        public async Task<Location> Get(int id)
        {
            return await _repositorio.Get(id);
        }

        public async Task<List<Location>> Get(Location item, int skip, int take)
        {
            return await _repositorio.Get(item, skip, take);
        }

        public async Task Insert(Location item)
        {
            await _repositorio.Insert(item);
        }

        public async Task Update(Location item)
        {
            await _repositorio.Update(item);
        }
    }
}
