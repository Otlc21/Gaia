using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
    public class Markup
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        public float PercentualAereo {  get; set; }

        [Required]
        public float PercentualCarro { get; set; }

        [Required]
        public float PercentualHotel { get; set; }

    }
}
