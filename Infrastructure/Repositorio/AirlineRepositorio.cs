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
    public class AirlineRepositorio : IAirlineRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Airline> _dbSet;

        public AirlineRepositorio(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Airline>();
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

        public async Task<int> Count(Airline item)
        {
            return await _dbSet.CountAsync();
        }

        public async Task<Airline> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Airline>> Get(Airline item, int skip, int take)
        {
            Expression<Func<Airline, bool>> filter = MakeFilter(item);

            return await _dbSet.Where(filter)
                .OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        private Expression<Func<Airline, bool>> MakeFilter(Airline item)
        {
            Expression<Func<Airline, bool>> filter = PredicateBuilder.New<Airline>();

            if (item == null)
                return filter;

            if (item.Id != 0)
                filter = filter.And(x => x.Id == item.Id);

            if (!string.IsNullOrEmpty(item.Name))
                filter = filter.And(x => x.Name.ToLower().Contains(item.Name.ToLower()));

            if (!string.IsNullOrEmpty(item.Country))
                filter = filter.And(x => x.Country.ToLower().Contains(item.Country.ToLower()));

            if (item.Creation != DateTime.MinValue)
                filter = filter.And(x => x.Creation == item.Creation);

            if (item.Active)
                filter = filter.And(x => x.Active == item.Active);

            return filter;
        }


        public async Task Insert(Airline item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Airline item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
