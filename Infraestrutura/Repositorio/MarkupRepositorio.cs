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
    public class MarkupRepositorio : IMarkupRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Markup> _dbSet;

        public MarkupRepositorio(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Markup>();
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

        public async Task<int> Count(Markup item)
        {
            return await _dbSet.CountAsync();
        }

        public async Task<Markup> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Markup>> Get(Markup item, int skip, int take)
        {
            Expression<Func<Markup, bool>> filter = MakeFilter(item);

            return await _dbSet.Where(filter)
                .OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        private Expression<Func<Markup, bool>> MakeFilter(Markup item)
        {
            Expression<Func<Markup, bool>> filter = PredicateBuilder.New<Markup>();

            if (item == null)
                return filter;

            if (item.Id != 0)
                filter = filter.And(x => x.Id == item.Id);

            return filter;
        }


        public async Task Insert(Markup item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Markup item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
