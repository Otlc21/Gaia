using Dominio.Entidade;
using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class HotelRepositorio : IHotelRepositorio
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Hotel> _dbSet;

        public HotelRepositorio(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Hotel>();
        }

        public async Task Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<int> Count(Hotel item)
        {
            return await _dbSet.CountAsync();
        }

        public async Task<Hotel> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Hotel>> Get(Hotel item, int skip, int take)
        {
            return await _dbSet.Where(x => 1 == 1)
                .OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task Insert(Hotel item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Hotel item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
