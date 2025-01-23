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
    public class HotelRepositorio : IHotelRepository
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
            Expression<Func<Hotel, bool>> filter = MakeFilter(item);

            return await _dbSet.Where(filter)
                .OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        private Expression<Func<Hotel, bool>> MakeFilter(Hotel item)
        {
            Expression<Func<Hotel, bool>> filter = PredicateBuilder.New<Hotel>();

            if (item == null)
                return filter;

            if (item.Id != 0)
                filter = filter.And(x => x.Id == item.Id);

            if (!string.IsNullOrEmpty(item.Name))
                filter = filter.And(x => x.Name.ToLower().Contains(item.Name.ToLower()));

            if (item.LocationId != 0)
                filter = filter.And(x => x.LocationId == item.LocationId);

            if (item.Rating != 0)
                filter = filter.And(x => x.Rating == item.Rating);

            if (!string.IsNullOrEmpty(item.Description))
                filter = filter.And(x => x.Description.ToLower().Contains(item.Description.ToLower()));

            if (item.Creation != DateTime.MinValue)
                filter = filter.And(x => x.Creation == item.Creation);

            if (item.Active)
                filter = filter.And(x => x.Active == item.Active);

            return filter;
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
