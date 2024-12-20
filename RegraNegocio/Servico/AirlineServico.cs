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
    public class AirlineServico : IAirlineServico
    {
        private readonly IAirlineRepositorio _repositorio;

        public AirlineServico(IAirlineRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task<int> Count(Airline item)
        {
            return await _repositorio.Count(item);
        }

        public async Task<Airline> Get(int id)
        {
            return await _repositorio.Get(id);
        }

        public async Task<List<Airline>> Get(Airline item, int skip, int take)
        {
            return await _repositorio.Get(item, skip, take);
        }

        public async Task Insert(Airline item)
        {
            await _repositorio.Insert(item);
        }

        public async Task Update(Airline item)
        {
            await _repositorio.Update(item);
        }
    }
}
