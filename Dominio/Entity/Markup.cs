using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entity
{
    public class Markup
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        public float Flight {  get; set; }

        [Required]
        public float Car { get; set; }

        [Required]
        public float Hotel { get; set; }

    }
}
