using Dominio.Entity;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class AirlineViewModel : BaseViewModel
    {
        public AirlineViewModel()
        {

        }

        public AirlineViewModel(Airline item)
        {
            Id = item.Id;
            Name = item.Name;
            Country = item.Country;
            Creation = item.Creation;
        }

        public Airline Convert()
        {
            return new Airline()
            {
                Id = this.Id,
                Name = this.Name,
                Country = this.Country,
                Creation = this.Creation,
            };
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        [Required]
        public bool Active { get; set; }

        public List<Airline> Itens { get; set; }
    }
}
