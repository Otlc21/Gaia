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
    public class RoomRepositorio : IRoomRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Room> _dbSet;

        public RoomRepositorio(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Room>();
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

        public async Task<int> Count(Room item)
        {
            return await _dbSet.CountAsync();
        }

        public async Task<Room> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Room>> Get(Room item, int skip, int take)
        {
            Expression<Func<Room, bool>> filter = MakeFilter(item);

            return await _dbSet.Where(filter)
                .OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        private Expression<Func<Room, bool>> MakeFilter(Room item)
        {
            Expression<Func<Room, bool>> filter = PredicateBuilder.New<Room>();

            if (item == null)
                return filter;

            if (item.Id != 0)
                filter = filter.And(x => x.Id == item.Id);

            if (item.HotelId != 0)
                filter = filter.And(x => x.HotelId == item.HotelId);

            if (!string.IsNullOrEmpty(item.Type))
                filter = filter.And(x => x.Type.ToLower().Contains(item.Type.ToLower()));

            if (item.Capacity != 0)
                filter = filter.And(x => x.Capacity == item.Capacity);

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


        public async Task Insert(Room item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Room item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
