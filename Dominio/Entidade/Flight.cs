using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AirportOrigemId { get; set; }

        [ForeignKey("AirportOrigemId")]
        public Airport AirportOrigem { get; set; }

        [Required]
        public int AirportDestinoId { get; set; }

        [ForeignKey("AirportDestinoId")]
        public Airport AirportDestino { get; set; }

        [Required]
        public int AirlineId { get; set; }

        [ForeignKey("AirlineId")]
        public Airline Airline { get; set; }

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
