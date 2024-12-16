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
    public class MarkupServico : IMarkupServico
    {
        private readonly IMarkupRepositorio _repositorio;

        public MarkupServico(IMarkupRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task<int> Count(Markup item)
        {
            return await _repositorio.Count(item);
        }

        public async Task<Markup> Get(int id)
        {
            return await _repositorio.Get(id);
        }

        public async Task<List<Markup>> Get(Markup item, int skip, int take)
        {
            return await _repositorio.Get(item, skip, take);
        }

        public async Task Insert(Markup item)
        {
            await _repositorio.Insert(item);
        }

        public async Task Update(Markup item)
        {
            await _repositorio.Update(item);
        }
    }
}
