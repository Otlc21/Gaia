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
    public class LocationRepositorio : ILocationRepositorio
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Location> _dbSet;

        public LocationRepositorio(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Location>();
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

        public async Task<int> Count(Location item)
        {
            return await _dbSet.CountAsync();
        }

        public async Task<Location> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Location>> Get(Location item, int skip, int take)
        {
            return await _dbSet.Where(x => 1 == 1)
                .OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task Insert(Location item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Location item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
