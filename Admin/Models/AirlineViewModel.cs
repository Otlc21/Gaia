using Dominio.Entity;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class AirlineViewModel : BaseViewModel
    {
        public AirlineViewModel()
        {

        }

        public AirlineViewModel(Airline item)
        {
            Id = item.Id;
            Nome = item.Name;
            Pais = item.Country;
            Criacao = item.Criacao;
        }

        public Airline Convert()
        {
            return new Airline()
            {
                Id = this.Id,
                Name = this.Nome,
                Country = this.Pais,
                Criacao = this.Criacao,
            };
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Pais { get; set; }

        [Required]
        public DateTime Criacao { get; set; }

        public List<Airline> Itens { get; set; }
    }
}
