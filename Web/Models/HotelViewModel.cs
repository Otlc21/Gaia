using Dominio.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class HotelViewModel : BaseViewModel
    {
        public HotelViewModel()
        {

        }

        public HotelViewModel(Hotel item)
        {
            Id = item.Id;
            Name = item.Name;
            LocationId = item.LocationId;
            Rating = item.Rating;
            Description = item.Description;
            Creation = item.Creation;
        }

        public Hotel Convert()
        {
            return new Hotel()
            {
                Id = this.Id,
                Name = this.Name,
                LocationId = this.LocationId,
                Rating = this.Rating,
                Description = this.Description,
                Creation = this.Creation,
            };
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [Required]
        public float Rating { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        [Required]
        public bool Active { get; set; }

        public List<Hotel> Itens { get; set; }
    }
}
