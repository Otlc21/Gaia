using Dominio.Entidade;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class AirportViewModel : BaseViewModel
    {
        public AirportViewModel()
        {

        }

        public AirportViewModel(Airport item)
        {
            Id = item.Id;
            Codigo = item.Codigo;
            Descricao = item.Descricao;
            LocationId = item.LocationId;
            Criacao = item.Criacao;
        }

        public Airport Convert()
        {
            return new Airport()
            {
                Id = this.Id,
                Codigo = this.Codigo,
                Descricao = this.Descricao,
                LocationId = this.LocationId,
                Criacao = this.Criacao,
            };
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [Required]
        public DateTime Criacao { get; set; }

        public List<Airport> Itens { get; set; }
    }
}
