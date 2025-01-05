using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entity
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
        public DateTime Departure { get; set; }

        [Required]
        public DateTime Arrival { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        public float Price {  get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public int Path { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
