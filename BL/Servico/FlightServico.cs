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
    public class FlightServico : IFlightService
    {
        private readonly IFlightRepository _repositorio;

        public FlightServico(IFlightRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task<int> Count(Flight item)
        {
            return await _repositorio.Count(item);
        }

        public async Task<Flight> Get(int id)
        {
            return await _repositorio.Get(id);
        }

        public async Task<List<Flight>> Get(Flight item, int skip, int take)
        {
            return await _repositorio.Get(item, skip, take);
        }

        public async Task Insert(Flight item)
        {
            await _repositorio.Insert(item);
        }

        public async Task Update(Flight item)
        {
            await _repositorio.Update(item);
        }
    }
}
