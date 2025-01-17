﻿using Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Service
{
    public interface ILocationService
    {
        Task<int> Count(Location item);
        Task<Location> Get(int id);
        Task<List<Location>> Get(Location item, int skip, int take);
        Task Insert(Location item);
        Task Update(Location item);
        Task Delete(int id);
    }
}
