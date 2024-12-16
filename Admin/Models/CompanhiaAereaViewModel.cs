using Dominio.Entidade;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class CompanhiaAereaViewModel : BaseViewModel
    {
        public CompanhiaAereaViewModel()
        {

        }

        public CompanhiaAereaViewModel(CompanhiaAerea item)
        {
            Id = item.Id;
            Nome = item.Nome;
            Pais = item.Pais;
            Criacao = item.Criacao;
        }

        public CompanhiaAerea Convert()
        {
            return new CompanhiaAerea()
            {
                Id = this.Id,
                Nome = this.Nome,
                Pais = this.Pais,
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
    }
}
