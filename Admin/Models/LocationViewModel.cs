using Dominio.Entity;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class LocationViewModel : BaseViewModel
    {
        public LocationViewModel()
        {

        }

        public LocationViewModel(Location item)
        {
            Id = item.Id;
            Cidade = item.City;
            Estado = item.State;
            Pais = item.Country;
            Criacao = item.Criacao;
        }

        public Location Convert()
        {
            return new Location()
            {
                Id = this.Id,
                City = this.Cidade,
                State = this.Estado,
                Country = this.Pais,
                Criacao = this.Criacao,
            };
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Pais { get; set; }

        [Required]
        public DateTime Criacao { get; set; }

        public List<Location> Itens { get; set; }
    }
}
