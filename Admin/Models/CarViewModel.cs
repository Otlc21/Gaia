using Dominio.Entidade;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class CarViewModel : BaseViewModel
    {
        public CarViewModel()
        {

        }

        public CarViewModel(Car item)
        {
            Id = item.Id;
            Modelo = item.Modelo;
            Marca = item.Marca;
            Ano = item.Ano;
            Categoria = item.Categoria;
            LocationId = item.LocationId;
            Preco = item.Preco;
            Quantidade = item.Quantidade;
            Criacao = item.Criacao;
        }

        public Car Convert()
        {
            return new Car()
            {
                Id = this.Id,
                Modelo = this.Modelo,
                Marca = this.Marca,
                Ano = this.Ano,
                Categoria = this.Categoria,
                LocationId = this.LocationId,
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
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [Required]
        public float Preco { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public DateTime Criacao { get; set; }

        public List<Car> Itens { get; set; }
    }
}
