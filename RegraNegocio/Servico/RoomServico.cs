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
    public class RoomServico : IRoomServico
    {
        private readonly IRoomRepositorio _repositorio;

        public RoomServico(IRoomRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task<int> Count(Room item)
        {
            return await _repositorio.Count(item);
        }

        public async Task<Room> Get(int id)
        {
            return await _repositorio.Get(id);
        }

        public async Task<List<Room>> Get(Room item, int skip, int take)
        {
            return await _repositorio.Get(item, skip, take);
        }

        public async Task Insert(Room item)
        {
            await _repositorio.Insert(item);
        }

        public async Task Update(Room item)
        {
            await _repositorio.Update(item);
        }
    }
}
