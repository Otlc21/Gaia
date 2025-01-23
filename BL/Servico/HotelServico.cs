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
    public class HotelServico : IHotelService
    {
        private readonly IHotelRepository _repositorio;

        public HotelServico(IHotelRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Delete(int id)
        {
            await _repositorio.Delete(id);
        }

        public async Task<int> Count(Hotel item)
        {
            return await _repositorio.Count(item);
        }

        public async Task<Hotel> Get(int id)
        {
            return await _repositorio.Get(id);
        }

        public async Task<List<Hotel>> Get(Hotel item, int skip, int take)
        {
            return await _repositorio.Get(item, skip, take);
        }
        public async Task Insert(Hotel item)
        {
            await _repositorio.Insert(item);
        }

        public async Task Update(Hotel item)
        {
            await _repositorio.Update(item);
        }
    }
}
