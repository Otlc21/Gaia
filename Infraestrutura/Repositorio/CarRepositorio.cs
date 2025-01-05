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
    public class CarRepositorio : ICarRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Car> _dbSet;

        public CarRepositorio(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Car>();
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

        public async Task<int> Count(Car item)
        {
            return await _dbSet.CountAsync();
        }

        public async Task<Car> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Car>> Get(Car item, int skip, int take)
        {
            Expression<Func<Car, bool>> filter = MakeFilter(item);

            return await _dbSet.Where(filter)
                .OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        private Expression<Func<Car, bool>> MakeFilter(Car item)
        {
            Expression<Func<Car, bool>> filter = PredicateBuilder.New<Car>();

            if (item == null)
                return filter;

            if (item.Id != 0)
                filter = filter.And(x => x.Id == item.Id);

            if (!string.IsNullOrEmpty(item.Model))
                filter = filter.And(x => x.Model.ToLower().Contains(item.Model.ToLower()));

            if (!string.IsNullOrEmpty(item.Brand))
                filter = filter.And(x => x.Brand.ToLower().Contains(item.Brand.ToLower()));

            if (item.Year != 0)
                filter = filter.And(x => x.Year == item.Year);

            if (!string.IsNullOrEmpty(item.Category))
                filter = filter.And(x => x.Category.ToLower().Contains(item.Category.ToLower()));

            if (item.LocationId != 0)
                filter = filter.And(x => x.LocationId == item.LocationId);

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


        public async Task Insert(Car item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Car item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
