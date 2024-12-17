using Dominio.Entidade;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Admin.Models
{
    public class AereoViewModel : BaseViewModel
    {
        public AereoViewModel()
        {
            
        }

        public AereoViewModel(Aereo item)
        {
            Id = item.Id;
            AeroportoOrigemId = item.AeroportoOrigemId;
            AeroportoDestinoId = item.AeroportoDestinoId;
            CompanhiaAereaId = item.CompanhiaAereaId;
            Partida = item.Partida;
            Chegada = item.Chegada;
            Classe = item.Classe;
            Preco = item.Preco;
            Quantidade = item.Quantidade;
            Criacao = item.Criacao;
        }

        public Aereo Convert()
        {
            return new Aereo()
            {
                Id = this.Id,
                AeroportoOrigemId = this.AeroportoOrigemId,
                AeroportoDestinoId = this.AeroportoDestinoId,
                CompanhiaAereaId = this.CompanhiaAereaId,
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
        public int AeroportoOrigemId { get; set; }

        [ForeignKey("AeroportoOrigemId")]
        public Aeroporto AeroportoOrigem { get; set; }

        [Required]
        public int AeroportoDestinoId { get; set; }

        [ForeignKey("AeroportoDestinoId")]
        public Aeroporto AeroportoDestino { get; set; }

        [Required]
        public int CompanhiaAereaId { get; set; }

        [ForeignKey("CompanhiaAereaId")]
        public CompanhiaAerea CompanhiaAerea { get; set; }

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

        public List<Aereo> Itens { get; set; }
    }
}
