using Dominio.Entidade;
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
            Nome = item.Nome;
            LocalizacaoId = item.LocalizacaoId;
            Avaliacao = item.Avaliacao;
            Descricao = item.Descricao;
            Criacao = item.Criacao;
        }

        public Hotel Convert()
        {
            return new Hotel()
            {
                Id = this.Id,
                Nome = this.Nome,
                LocalizacaoId = this.LocalizacaoId,
                Avaliacao = this.Avaliacao,
                Descricao = this.Descricao,
                Criacao = this.Criacao,
            };
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int LocalizacaoId { get; set; }

        [ForeignKey("LocalizacaoId")]
        public Localizacao Localizacao { get; set; }

        [Required]
        public float Avaliacao { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime Criacao { get; set; }
    }
}
