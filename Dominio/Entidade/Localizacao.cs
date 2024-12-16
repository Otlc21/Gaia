using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
    public class Localizacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Cidade {  get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Pais { get; set; }

        [Required]
        public DateTime Criacao { get; set; }

    }
}
