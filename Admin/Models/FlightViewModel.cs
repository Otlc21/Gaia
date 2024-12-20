using Dominio.Entidade;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Admin.Models
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
            Partida = item.Partida;
            Chegada = item.Chegada;
            Classe = item.Classe;
            Preco = item.Preco;
            Quantidade = item.Quantidade;
            Criacao = item.Criacao;
        }

        public Flight Convert()
        {
            return new Flight()
            {
                Id = this.Id,
                AirportOrigemId = this.AirportOrigemId,
                AirportDestinoId = this.AirportDestinoId,
                AirlineId = this.AirlineId,
                Partida = this.Partida,
                Chegada = this.Chegada,
                Classe = this.Classe,
                Preco = this.Preco,
                Quantidade = this.Quantidade,
                Criacao = this.Criacao,
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
        public DateTime Partida { get; set; }

        [Required]
        public DateTime Chegada { get; set; }

        [Required]
        public string Classe { get; set; }

        [Required]
        public float Preco { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public DateTime Criacao { get; set; }

        public List<Flight> Itens { get; set; }
    }
}
