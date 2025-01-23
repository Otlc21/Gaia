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
    public class AirportRepositorio : IAirportRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Airport> _dbSet;

        public AirportRepositorio(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Airport>();
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

        public async Task<int> Count(Airport item)
        {
            return await _dbSet.CountAsync();
        }

        public async Task<Airport> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Airport>> Get(Airport item, int skip, int take)
        {
            Expression<Func<Airport, bool>> filter = MakeFilter(item);

            return await _dbSet.Where(filter)
                .OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        private Expression<Func<Airport, bool>> MakeFilter(Airport item)
        {
            Expression<Func<Airport, bool>> filter = PredicateBuilder.New<Airport>();

            if (item == null)
                return filter;

            if (item.Id != 0)
                filter = filter.And(x => x.Id == item.Id);

            if (!string.IsNullOrEmpty(item.Code))
                filter = filter.And(x => x.Code.ToLower().Contains(item.Code.ToLower()));

            if (!string.IsNullOrEmpty(item.Description))
                filter = filter.And(x => x.Description.ToLower().Contains(item.Description.ToLower()));

            if (item.LocationId != 0)
                filter = filter.And(x => x.LocationId == item.LocationId);

            if (item.Creation != DateTime.MinValue)
                filter = filter.And(x => x.Creation == item.Creation);

            if (item.Active)
                filter = filter.And(x => x.Active == item.Active);

            return filter;
        }


        public async Task Insert(Airport item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Airport item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
