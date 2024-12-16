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
    public class QuartoServico : IQuartoServico
    {
        private readonly IQuartoRepositorio _repositorio;

        public QuartoServico(IQuartoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task<int> Count(Quarto item)
        {
            return await _repositorio.Count(item);
        }

        public async Task<Quarto> Get(int id)
        {
            return await _repositorio.Get(id);
        }

        public async Task<List<Quarto>> Get(Quarto item, int skip, int take)
        {
            return await _repositorio.Get(item, skip, take);
        }

        public async Task Insert(Quarto item)
        {
            await _repositorio.Insert(item);
        }

        public async Task Update(Quarto item)
        {
            await _repositorio.Update(item);
        }
    }
}
