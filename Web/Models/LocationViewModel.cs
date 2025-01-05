using Dominio.Entity;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class LocationViewModel : BaseViewModel
    {
        public LocationViewModel()
        {

        }

        public LocationViewModel(Location item)
        {
            Id = item.Id;
            City = item.City;
            State = item.State;
            Country = item.Country;
            Creation = item.Creation;
        }

        public Location Convert()
        {
            return new Location()
            {
                Id = this.Id,
                City = this.City,
                State = this.State,
                Country = this.Country,
                Creation = this.Creation,
            };
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        [Required]
        public bool Active { get; set; }

        public List<Location> Itens { get; set; }
    }
}
