using Dominio.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Models
{
    public class FlightViewModel : BaseViewModel
    {
        public FlightViewModel()
        {
            
        }

        public FlightViewModel(Flight item)
        {
            Id = item.Id;
            AirportOrigemId = item.AirportOrigemId;
            AirportDestinoId = item.AirportDestinoId;
            AirlineId = item.AirlineId;
            Departure = item.Departure;
            Arrival = item.Arrival;
            Classe = item.Class;
            Class = item.Price;
            Amount = item.Amount;
            Creation = item.Creation;
        }

        public Flight Convert()
        {
            return new Flight()
            {
                Id = this.Id,
                AirportOrigemId = this.AirportOrigemId,
                AirportDestinoId = this.AirportDestinoId,
                AirlineId = this.AirlineId,
                Departure = this.Departure,
                Arrival = this.Arrival,
                Class = this.Classe,
                Price = this.Class,
                Amount = this.Amount,
                Creation = this.Creation,
            };
        }

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
        public string Classe { get; set; }

        [Required]
        public float Class { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        [Required]
        public bool Active { get; set; }
        public List<Flight> Itens { get; set; }

        public IEnumerable<SelectListItem> Airports { get; set; }
        public IEnumerable<SelectListItem> Airlines { get; set; }
    }
}
