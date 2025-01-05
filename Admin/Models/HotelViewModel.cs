using Dominio.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class HotelViewModel : BaseViewModel
    {
        public HotelViewModel()
        {

        }

        public HotelViewModel(Hotel item)
        {
            Id = item.Id;
            Nome = item.Name;
            LocationId = item.LocationId;
            Avaliacao = item.Rating;
            Descricao = item.Description;
            Criacao = item.Criacao;
        }

        public Hotel Convert()
        {
            return new Hotel()
            {
                Id = this.Id,
                Name = this.Nome,
                LocationId = this.LocationId,
                Rating = this.Avaliacao,
                Description = this.Descricao,
                Criacao = this.Criacao,
            };
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [Required]
        public float Avaliacao { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime Criacao { get; set; }

        public List<Hotel> Itens { get; set; }
    }
}
