﻿using Dominio.Entity;
using Dominio.Repository;
using Dominio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegraNegocio.Servico
{
    public class AirportServico : IAirportService
    {
        private readonly IAirportRepository _repositorio;

        public AirportServico(IAirportRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task<int> Count(Airport item)
        {
            return await _repositorio.Count(item);
        }

        public async Task<Airport> Get(int id)
        {
            return await _repositorio.Get(id);
        }

        public async Task<List<Airport>> Get(Airport item, int skip, int take)
        {
            return await _repositorio.Get(item, skip, take);
        }

        public async Task Insert(Airport item)
        {
            await _repositorio.Insert(item);
        }

        public async Task Update(Airport item)
        {
            await _repositorio.Update(item);
        }
    }
}
