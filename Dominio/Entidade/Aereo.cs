using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
    public class Aereo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AeroportoOrigemId { get; set; }

        [ForeignKey("AeroportoOrigemId")]
        public Aeroporto AeroportoOrigem { get; set; }

        [Required]
        public int AeroportoDestinoId { get; set; }

        [ForeignKey("AeroportoDestinoId")]
        public Aeroporto AeroportoDestino { get; set; }

        [Required]
        public int CompanhiaAereaId { get; set; }

        [ForeignKey("CompanhiaAereaId")]
        public CompanhiaAerea CompanhiaAerea { get; set; }

        [Required]
        public DateTime Partida { get; set; }

        [Required]
        public DateTime Chegada { get; set; }

        [Required]
        public string Classe { get; set; }

        [Required]
        public float Preco {  get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public DateTime Criacao { get; set; }
    }
}
