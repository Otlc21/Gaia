using Domain.Entity;
using Domain.Repository;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorio
{
    public class LocationRepositorio : ILocationRepository
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
            Expression<Func<Location, bool>> filter = MakeFilter(item);

            return await _dbSet.Where(filter)
                .OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        private Expression<Func<Location, bool>> MakeFilter(Location item)
        {
            Expression<Func<Location, bool>> filter = PredicateBuilder.New<Location>();

            if (item == null)
                return filter;

            if (item.Id != 0)
                filter = filter.And(x => x.Id == item.Id);

            if (!string.IsNullOrEmpty(item.City))
                filter = filter.And(x => x.City.ToLower().Contains(item.City.ToLower()));

            if (!string.IsNullOrEmpty(item.State))
                filter = filter.And(x => x.State.ToLower().Contains(item.State.ToLower()));

            if (!string.IsNullOrEmpty(item.Country))
                filter = filter.And(x => x.Country.ToLower().Contains(item.Country.ToLower()));

            if (item.Creation != DateTime.MinValue)
                filter = filter.And(x => x.Creation == item.Creation);

            if (item.Active)
                filter = filter.And(x => x.Active == item.Active);

            return filter;
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
