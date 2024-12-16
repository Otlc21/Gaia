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
    public class LocalizacaoServico : ILocalizacaoServico
    {
        private readonly ILocalizacaoRepositorio _repositorio;

        public LocalizacaoServico(ILocalizacaoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task<int> Count(Localizacao item)
        {
            return await _repositorio.Count(item);
        }

        public async Task<Localizacao> Get(int id)
        {
            return await _repositorio.Get(id);
        }

        public async Task<List<Localizacao>> Get(Localizacao item, int skip, int take)
        {
            return await _repositorio.Get(item, skip, take);
        }

        public async Task Insert(Localizacao item)
        {
            await _repositorio.Insert(item);
        }

        public async Task Update(Localizacao item)
        {
            await _repositorio.Update(item);
        }
    }
}
