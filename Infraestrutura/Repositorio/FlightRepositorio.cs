using Dominio.Entity;
using Dominio.Repository;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class FlightRepositorio : IFlightRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Flight> _dbSet;

        public FlightRepositorio(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Flight>();
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

        public async Task<int> Count(Flight item)
        {
            return await _dbSet.CountAsync();
        }

        public async Task<Flight> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Flight>> Get(Flight item, int skip, int take)
        {
            Expression<Func<Flight, bool>> filter = MakeFilter(item);

            return await _dbSet.Where(filter)
                .OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        private Expression<Func<Flight, bool>> MakeFilter(Flight item)
        {
            Expression<Func<Flight, bool>> filter = PredicateBuilder.New<Flight>();

            if (item == null)
                return filter;

            if (item.Id != 0)
                filter = filter.And(x => x.Id == item.Id);

            if (item.AirportOrigemId != 0)
                filter = filter.And(x => x.AirportOrigemId == item.AirportOrigemId);

            if (item.AirportDestinoId != 0)
                filter = filter.And(x => x.AirportDestinoId == item.AirportDestinoId);

            if (item.AirlineId != 0)
                filter = filter.And(x => x.AirlineId == item.AirlineId);

            if (item.Departure != DateTime.MinValue)
                filter = filter.And(x => x.Departure == item.Departure);

            if (item.Arrival != DateTime.MinValue)
                filter = filter.And(x => x.Arrival == item.Arrival);

            if (!string.IsNullOrEmpty(item.Class))
                filter = filter.And(x => x.Class.ToLower().Contains(item.Class.ToLower()));

            if (item.Price != 0)
                filter = filter.And(x => x.Price == item.Price);

            if (item.Amount != 0)
                filter = filter.And(x => x.Amount == item.Amount);

            if (item.Creation != DateTime.MinValue)
                filter = filter.And(x => x.Creation == item.Creation);

            if (item.Active)
                filter = filter.And(x => x.Active == item.Active);

            return filter;
        }

        public async Task Insert(Flight item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Flight item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
