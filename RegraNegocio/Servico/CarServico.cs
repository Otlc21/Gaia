﻿using Dominio.Entidade;
using Dominio.Repositorio;
using Dominio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegraNegocio.Servico
{
    public class CarServico : ICarServico
    {
        private readonly ICarRepositorio _repositorio;

        public CarServico(ICarRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task<int> Count(Car item)
        {
            return await _repositorio.Count(item);
        }

        public async Task<Car> Get(int id)
        {
            return await _repositorio.Get(id);
        }

        public async Task<List<Car>> Get(Car item, int skip, int take)
        {
            return await _repositorio.Get(item, skip, take);
        }

        public async Task Insert(Car item)
        {
            await _repositorio.Insert(item);
        }

        public async Task Update(Car item)
        {
            await _repositorio.Update(item);
        }
    }
}
