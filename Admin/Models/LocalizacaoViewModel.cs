using Dominio.Entidade;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class LocalizacaoViewModel : BaseViewModel
    {
        public LocalizacaoViewModel()
        {

        }

        public LocalizacaoViewModel(Localizacao item)
        {
            Id = item.Id;
            Cidade = item.Cidade;
            Estado = item.Estado;
            Pais = item.Pais;
            Criacao = item.Criacao;
        }

        public Localizacao Convert()
        {
            return new Localizacao()
            {
                Id = this.Id,
                Cidade = this.Cidade,
                Estado = this.Estado,
                Pais = this.Pais,
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

        public List<Localizacao> Itens { get; set; }
    }
}
