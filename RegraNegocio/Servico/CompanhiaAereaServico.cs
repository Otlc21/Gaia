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
    public class CompanhiaAereaServico : ICompanhiaAereaServico
    {
        private readonly ICompanhiaAereaRepositorio _repositorio;

        public CompanhiaAereaServico(ICompanhiaAereaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task<int> Count(CompanhiaAerea item)
        {
            return await _repositorio.Count(item);
        }

        public async Task<CompanhiaAerea> Get(int id)
        {
            return await _repositorio.Get(id);
        }

        public async Task<List<CompanhiaAerea>> Get(CompanhiaAerea item, int skip, int take)
        {
            return await _repositorio.Get(item, skip, take);
        }

        public async Task Insert(CompanhiaAerea item)
        {
            await _repositorio.Insert(item);
        }

        public async Task Update(CompanhiaAerea item)
        {
            await _repositorio.Update(item);
        }
    }
}
