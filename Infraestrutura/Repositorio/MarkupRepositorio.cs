﻿using Dominio.Entidade;
using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class MarkupRepositorio : IMarkupRepositorio
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
            return await _dbSet.Where(x => 1 == 1)
                .OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
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
