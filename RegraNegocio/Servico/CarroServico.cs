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
    public class CarroServico : ICarroServico
    {
        private readonly ICarroRepositorio _repositorio;

        public CarroServico(ICarroRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task<int> Count(Carro item)
        {
            return await _repositorio.Count(item);
        }

        public async Task<Carro> Get(int id)
        {
            return await _repositorio.Get(id);
        }

        public async Task<List<Carro>> Get(Carro item, int skip, int take)
        {
            return await _repositorio.Get(item, skip, take);
        }

        public async Task Insert(Carro item)
        {
            await _repositorio.Insert(item);
        }

        public async Task Update(Carro item)
        {
            await _repositorio.Update(item);
        }
    }
}
