using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public interface IAirportService
    {
        Task<List<AirportName>> Get(string text, string culture, int skip = 0, int take = 10);
    }
}
