using Dominio.Entidade;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class CarroViewModel : BaseViewModel
    {
        public CarroViewModel()
        {

        }

        public CarroViewModel(Carro item)
        {
            Id = item.Id;
            Modelo = item.Modelo;
            Marca = item.Marca;
            Ano = item.Ano;
            Categoria = item.Categoria;
            LocalizacaoId = item.LocalizacaoId;
            Preco = item.Preco;
            Quantidade = item.Quantidade;
            Criacao = item.Criacao;
        }

        public Carro Convert()
        {
            return new Carro()
            {
                Id = this.Id,
                Modelo = this.Modelo,
                Marca = this.Marca,
                Ano = this.Ano,
                Categoria = this.Categoria,
                LocalizacaoId = this.LocalizacaoId,
                Preco = this.Preco,
                Quantidade = this.Quantidade,
                Criacao = this.Criacao,
            };
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public short Ano { get; set; }

        [Required]
        public string Categoria { get; set; }

        [Required]
        public int LocalizacaoId { get; set; }

        [ForeignKey("LocalizacaoId")]
        public Localizacao Localizacao { get; set; }

        [Required]
        public float Preco { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public DateTime Criacao { get; set; }
    }
}
