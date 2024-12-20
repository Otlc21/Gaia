using Dominio.Entidade;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class RoomViewModel : BaseViewModel
    {
        public RoomViewModel()
        {

        }

        public RoomViewModel(Room item)
        {
            Id = item.Id;
            HotelId = item.HotelId;
            Tipo = item.Tipo;
            Capacidade = item.Capacidade;
            Preco = item.Preco;
            Quantidade = item.Quantidade;
            Criacao = item.Criacao;
        }

        public Room Convert()
        {
            return new Room()
            {
                Id = this.Id,
                HotelId = this.HotelId,
                Tipo = this.Tipo,
                Capacidade = this.Capacidade,
                Preco = this.Preco,
                Quantidade = this.Quantidade,
                Criacao = this.Criacao,
            };
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int HotelId { get; set; }

        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public byte Capacidade { get; set; }

        [Required]
        public float Preco { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public DateTime Criacao { get; set; }

        public List<Room> Itens { get; set; }
    }
}
