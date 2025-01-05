using Dominio.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
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
            Type = item.Type;
            Capacity = item.Capacity;
            Price = item.Price;
            Amount = item.Amount;
            Creation = item.Creation;
        }

        public Room Convert()
        {
            return new Room()
            {
                Id = this.Id,
                HotelId = this.HotelId,
                Type = this.Type,
                Capacity = this.Capacity,
                Price = this.Price,
                Amount = this.Amount,
                Creation = this.Creation,
            };
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int HotelId { get; set; }

        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public byte Capacity { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        [Required]
        public bool Active { get; set; }

        public List<Room> Itens { get; set; }
    }
}
