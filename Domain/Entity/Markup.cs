using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Markup
    {
        public decimal Car { get; set; }
        public decimal Flight { get; set; }
        public decimal Hotel { get; set; }
    }
}
