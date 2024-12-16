using Dominio.Entidade;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class AeroportoViewModel : BaseViewModel
    {
        public AeroportoViewModel()
        {

        }

        public AeroportoViewModel(Aeroporto item)
        {
            Id = item.Id;
            Codigo = item.Codigo;
            Descricao = item.Descricao;
            LocalizacaoId = item.LocalizacaoId;
            Criacao = item.Criacao;
        }

        public Aeroporto Convert()
        {
            return new Aeroporto()
            {
                Id = this.Id,
                Codigo = this.Codigo,
                Descricao = this.Descricao,
                LocalizacaoId = this.LocalizacaoId,
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
        public int LocalizacaoId { get; set; }

        [ForeignKey("LocalizacaoId")]
        public Localizacao Localizacao { get; set; }

        [Required]
        public DateTime Criacao { get; set; }
    }
}
