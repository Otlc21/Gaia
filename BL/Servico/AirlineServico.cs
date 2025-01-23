using Domain.Entity;
using Domain.Repository;
using Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Servico
{
    public class AirlineServico : IAirlineService
    {
        private readonly IAirlineRepository _repositorio;

        public AirlineServico(IAirlineRepository repositorio)
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
